namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesByGenres = context
				.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = context.Games
						.Where(cg => cg.Genre.Name == g.Name && cg.Purchases.Count > 0)
						.Select(cg => new
						{
							Id = cg.Id,
							Title = cg.Name,
							Developer = cg.Developer.Name,
							Tags = string.Join(", ", cg.GameTags.Select(gt => gt.Tag.Name)),
							Players = cg.Purchases.Count
						})
						.OrderByDescending(x => x.Players)
						.ThenBy(x => x.Id)
						.ToArray(),
					TotalPlayers = g.Games.Sum(x => x.Purchases.Count)
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id);

			string gamesAsJsonString = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

			return gamesAsJsonString;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserPurchasesDto[]), xmlRoot);
			XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
			serializerNamespaces.Add(string.Empty, string.Empty);

			ExportUserPurchasesDto[] users = context
				.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Count > 0))
				.Select(u => new ExportUserPurchasesDto()
				{
					Username = u.Username,
					Purchases = u.Cards.Select(c => c.Purchases).SelectMany(p => p)
						.Where(p => p.Type.ToString() == storeType)
						.OrderByDescending(p => p.Date)
						.Select(p => new ExportPurchaseDto 
						{
							Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price.ToString()
                            }
                        })
						.ToArray(),
					TotalSpent = u.Cards.Sum(c => c.Purchases.Sum(p => p.Game.Price))
				})
				.Where(p => p.Purchases.Any())
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			StringBuilder sb = new StringBuilder();
			StringWriter stringWriter = new StringWriter(sb); ;

			xmlSerializer.Serialize(stringWriter, users, serializerNamespaces);

			return sb.ToString().TrimEnd();
		}
	}
}

//Purchases = (ExportPurchaseDto[])u.Cards
//                   .Select(c => c.Purchases
//                       .SelectMany(p => new ExportPurchaseDto
//                       {
//                           Card = p.Card.Number,
//                           Cvc = p.Card.Cvc,
//                           Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
//                           Game = new ExportGameDto()
//                           {
//                               Title = p.Game.Name,
//                               Genre = p.Game.Genre.Name,
//                               Price = p.Game.Price.ToString()
//                           }
//                       }))
//                   .ToArray(),