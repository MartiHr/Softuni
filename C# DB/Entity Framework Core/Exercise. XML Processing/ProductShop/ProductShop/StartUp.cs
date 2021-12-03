using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersXmlAsString = File.ReadAllText("Datasets/users.xml");
            string productsXmlAsString = File.ReadAllText("Datasets/products.xml");
            string categoriesXmlAsString = File.ReadAllText("Datasets/categories.xml");
            string categoriesProductsXmlAsString = File.ReadAllText("Datasets/categories-products.xml");

            Console.WriteLine(ImportUsers(context, usersXmlAsString));
            Console.WriteLine(ImportProducts(context, productsXmlAsString));
            Console.WriteLine(ImportCategories(context, categoriesXmlAsString));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXmlAsString));

            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportUserDto[] userDtos = (ImportUserDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            User[] users = mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportProductDto[] productDtos = (ImportProductDto[])xmlSerializer.Deserialize(stringReader);
           
            InitializeMapper();
            Product[] products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportCategoryDto[] categoryDtos = (ImportCategoryDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            Category[] categories = mapper.Map<Category[]>(categoryDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportCategoryProductDto[] categoryProductDtos = (ImportCategoryProductDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductDtos);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static void InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportProductsInRangeDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, products, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserWithSoldProductsDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportUserWithSoldProductsDto[] userWithSoldProductsDtos = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserWithSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new SoldProductDto()
                    {
                        Name = ps.Name,
                        Price = ps.Price.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, userWithSoldProductsDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductsCountDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportCategoryByProductsCountDto[] categories = context
                .Categories
                .Select(c => new ExportCategoryByProductsCountDto
                {
                    Name = c.Name,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.TotalRevenue)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, categories, serializerNamespaces);

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserRootDto), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            var userWithProductsDtos = new UserRootDto
            {
                Count = context.Users.Where(u => u.ProductsSold.Count > 0).Count().ToString(),
                Users = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new ExportUserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age.ToString(),
                    SoldProducts = new ExportSoldProductDto()
                    {
                        Count = u.ProductsSold.Count.ToString(),
                        SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .OrderByDescending(ps => ps.Price)
                        .Select(ps => new SoldProductDto
                        {
                            Name = ps.Name,
                            Price = ps.Price.ToString()
                        })
                        .ToArray()
                    }
                })
                .ToArray()
            };

            xmlSerializer.Serialize(stringWriter, userWithProductsDtos, serializerNamespaces);

            return sb.ToString().Trim();
        }
    }
}