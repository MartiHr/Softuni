namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .ToArray()
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks.Select(ab => ab.Book)
                        .ToArray()
                        .OrderByDescending(b => b.Price)
                        .Select(b => new
                        {
                            BookName = b.Name,
                            BookPrice = b.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string authorsAsString = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return authorsAsString;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportBookDto[] books = context
                .Books
                .ToArray()
                .Where(b => b.PublishedOn < date)
                .Where(b => b.Genre.ToString() == "Science")
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportBookDto()
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    Pages = b.Pages.ToString()
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, books, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}