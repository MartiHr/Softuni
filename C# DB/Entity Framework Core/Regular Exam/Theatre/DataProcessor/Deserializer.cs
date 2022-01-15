namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            StringReader stringReader = new StringReader(xmlString);
            ImportPlayDto[] importPlayDtos = (ImportPlayDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            ICollection<Play> plays = new HashSet<Play>();
            foreach (var playDto in importPlayDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool IsDurationValid =
                    TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration);

                if (!IsDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.TotalMinutes < 60)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (playDto.Genre != "Drama" 
                    && playDto.Genre != "Comedy"
                    && playDto.Genre != "Romance"
                    && playDto.Genre != "Musical")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);

                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            StringReader stringReader = new StringReader(xmlString);
            ImportCastDto[] importCastDtos = (ImportCastDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            ICollection<Cast> casts = new HashSet<Cast>();
            foreach (var castDto in importCastDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreTicketsDto[] importTheatreTicketsDtos = 
                JsonConvert.DeserializeObject<ImportTheatreTicketsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            ICollection<Theatre> theatres = new HashSet<Theatre>();
            foreach (var theatreTicketsDto in importTheatreTicketsDtos)
            {
                if (!IsValid(theatreTicketsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Ticket> tickets = new HashSet<Ticket>();
                foreach (var ticketDto in theatreTicketsDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    tickets.Add(ticket);
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreTicketsDto.Name,
                    NumberOfHalls = theatreTicketsDto.NumberOfHalls,
                    Director = theatreTicketsDto.Director,
                    Tickets = tickets
                };

                theatres.Add(theatre);

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, tickets.Count));
            }

            context.Theatres.AddRange(theatres);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
