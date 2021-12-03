namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ImportGameDto[] importGameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            foreach (var importGameDto in importGameDtos)
            {
                if (!IsValid(importGameDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				bool isReleaseDateValid = DateTime.TryParseExact(importGameDto.ReleaseDate,
					"yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isReleaseDateValid)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Developer developer = context
					.Developers
					.FirstOrDefault(d => d.Name == importGameDto.Developer);

                if (developer == null)
                {
					developer = new Developer()
					{
						Name = importGameDto.Developer
					};

					context.Developers.Add(developer);
					context.SaveChanges();
				}

				Genre genre = context
					.Genres
					.FirstOrDefault(g => g.Name == importGameDto.Genre);

				if (genre == null)
				{
					genre = new Genre()
					{
						Name = importGameDto.Genre
					};

					context.Genres.Add(genre);
					context.SaveChanges();
				}

				ICollection<Tag> tags = new List<Tag>();
                foreach (var tag in importGameDto.Tags)
                {
					Tag currentTag = context
						.Tags
						.FirstOrDefault(t => t.Name == tag);

                    if (currentTag == null)
                    {
						currentTag = new Tag()
						{
							Name = tag
						};

						context.Tags.Add(currentTag);
						context.SaveChanges();
					}

					tags.Add(currentTag);
                }

				Game currentGame = new Game()
				{
					Name = importGameDto.Name,
					Price = importGameDto.Price,
					ReleaseDate = releaseDate,
					Developer = developer,
					Genre = genre
				};

                foreach (var tag in tags)
                {
					GameTag currentGameTag = new GameTag()
					{
						Game = currentGame,
						Tag = tag
					};

					currentGame.GameTags.Add(currentGameTag);
                }

				context.Games.Add(currentGame);
				context.SaveChanges();

				sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre.Name}) with {tags.Count} tags");
			}

			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ImportUserDto[] importUserDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            foreach (var userDto in importUserDtos)
            {
                if (!IsValid(userDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				User currentUser = new User()
				{
					FullName = userDto.FullName,
					Username = userDto.Username,
					Email = userDto.Email,
					Age = int.Parse(userDto.Age)
				};

				bool AreCardsValid = true;

				ICollection<Card> userCards = new List<Card>();
                foreach (var cardDto in userDto.Cards)
                {
					if (!IsValid(cardDto) || (cardDto.Type != "Debit" && cardDto.Type != "Credit"))
					{
						AreCardsValid = false;
						break;
					}

					Card currentCard = new Card()
					{
						Number = cardDto.Number,
						Cvc = cardDto.Cvc,
						Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type)
					};

					userCards.Add(currentCard);
				}

				if (!AreCardsValid)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				currentUser.Cards = userCards;

				sb.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count} cards");
				context.Users.Add(currentUser);
            }

			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

			StringReader stringReader = new StringReader(xmlString);
			ImportPurchaseDto[] importPurchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var purchaseDto in importPurchaseDtos)
            {
                if (!IsValid(purchaseDto) || (purchaseDto.Type != "Retail" && purchaseDto.Type != "Digital"))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				Game game = context
					.Games
					.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (game == null)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Card card = context
					.Cards
					.FirstOrDefault(c => c.Number == purchaseDto.Card);

				if (card == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool isDateValid = DateTime.TryParseExact
					(purchaseDto.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime purchaseDate);

                if (!isDateValid)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Purchase currentPurchase = new Purchase()
				{
					Game = game,
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
					ProductKey = purchaseDto.Key,
					Card = card,
					Date = purchaseDate
				};

				context.Purchases.Add(currentPurchase);

				sb.AppendLine($"Imported {currentPurchase.Game.Name} for {currentPurchase.Card.User.Username}");
            }

			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}