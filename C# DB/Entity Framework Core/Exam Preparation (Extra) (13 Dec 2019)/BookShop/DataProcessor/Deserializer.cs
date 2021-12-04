namespace BookShop.DataProcessor
{
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), xmlRoot);

            StringReader stringReader = new StringReader(xmlString);
            ImportBookDto[] bookDtos = (ImportBookDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool IsPublishDateValid =
                    DateTime.TryParseExact(bookDto.PublishedOn,
                    "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn);

                if (!IsPublishDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            ImportAuthorBooksDto[] authorBooksDtos = JsonConvert.DeserializeObject<ImportAuthorBooksDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var authorBooksDto in authorBooksDtos)
            {
                if (!IsValid(authorBooksDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Authors.Any(a => a.Email == authorBooksDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = authorBooksDto.FirstName,
                    LastName = authorBooksDto.LastName,
                    Phone = authorBooksDto.Phone,
                    Email = authorBooksDto.Email,
                };

                ICollection<AuthorBook> authorBooks = new List<AuthorBook>();
                foreach (var bookDto in authorBooksDto.Books)
                {
                    Book book = context
                        .Books
                        .FirstOrDefault(b => b.Id == bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    if (!context.Books.Contains(book))
                    {
                        continue;
                    }

                    AuthorBook authorBook = new AuthorBook()
                    {
                        Book = book,
                        Author = author
                    };

                    authorBooks.Add(authorBook);
                }

                if (authorBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                author.AuthorsBooks = authorBooks;

                context.Authors.Add(author);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", authorBooks.Count));
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