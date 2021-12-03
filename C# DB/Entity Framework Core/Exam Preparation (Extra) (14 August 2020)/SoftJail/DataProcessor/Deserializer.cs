namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentCellsDto[] importDepartmenCellsDtos =
                JsonConvert.DeserializeObject<ImportDepartmentCellsDto[]>(jsonString);

            foreach (var departmentCellsDto in importDepartmenCellsDtos)
            {
                if (!IsValid(departmentCellsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool areAllCellsValid = true;

                ICollection<Cell> cells = new List<Cell>();
                foreach (var cellDto in departmentCellsDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        areAllCellsValid = false;
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                if (!areAllCellsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentCellsDto.Name,
                    Cells = cells
                };

                context.Departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {cells.Count} cells");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerMailsDto[] importPrisonerMailsDtos =
                JsonConvert.DeserializeObject<ImportPrisonerMailsDto[]>(jsonString);

            foreach (var prisonerMailsDto in importPrisonerMailsDtos)
            {
                if (!IsValid(prisonerMailsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIncarcerationDateValid =
                    DateTime.TryParseExact(prisonerMailsDto.IncarcerationDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isReleaseDateValid =
                    DateTime.TryParseExact(prisonerMailsDto.ReleaseDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isReleaseDateValid && prisonerMailsDto.ReleaseDate != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool areMailsValid = true;

                ICollection<Mail> mails = new List<Mail>();
                foreach (var mailDto in prisonerMailsDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        areMailsValid = false;
                        break;
                    }

                    Mail mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                if (!areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerMailsDto.FullName,
                    Nickname = prisonerMailsDto.Nickname,
                    Age = prisonerMailsDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerMailsDto.Bail,
                    CellId = prisonerMailsDto.CellId,
                    Mails = mails
                };

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                context.Prisoners.Add(prisoner);
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerPrisonersDto[]), xmlRoot);

            StringReader stringReader = new StringReader(xmlString);
            ImportOfficerPrisonersDto[] importOfficerPrisonersDtos =
                (ImportOfficerPrisonersDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var importOfficerPrisonersDto in importOfficerPrisonersDtos)
            {
                if (!IsValid(importOfficerPrisonersDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importOfficerPrisonersDto.Position != "Overseer"
                    && importOfficerPrisonersDto.Position != "Guard"
                    && importOfficerPrisonersDto.Position != "Watcher"
                    && importOfficerPrisonersDto.Position != "Labour")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importOfficerPrisonersDto.Weapon != "Knife"
                  && importOfficerPrisonersDto.Weapon != "FlashPulse"
                  && importOfficerPrisonersDto.Weapon != "ChainRifle"
                  && importOfficerPrisonersDto.Weapon != "Pistol"
                  && importOfficerPrisonersDto.Weapon != "Sniper")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = importOfficerPrisonersDto.FullName,
                    Salary = importOfficerPrisonersDto.Salary,
                    Position = (Position)Enum.Parse(typeof(Position), importOfficerPrisonersDto.Position),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon), importOfficerPrisonersDto.Weapon),
                    DepartmentId = importOfficerPrisonersDto.DepartmentId
                };

                foreach (var prisonerDto in importOfficerPrisonersDto.Prisoners)
                {
                    OfficerPrisoner prisoner = new OfficerPrisoner()
                    {
                        PrisonerId = prisonerDto.Id,
                        Officer = officer
                    };

                    officer.OfficerPrisoners.Add(prisoner);
                }

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");

                context.Officers.Add(officer);
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}