using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            string usersJsonAsString = File.ReadAllText("Datasets/users.json");
            string productsJsonAsString = File.ReadAllText("Datasets/products.json");
            string categoriesJsonAsString = File.ReadAllText("Datasets/categories.json");
            string categoriesProductsJsonAsString = File.ReadAllText("Datasets/categories-products.json");

            Console.WriteLine(ImportUsers(context, usersJsonAsString));
            Console.WriteLine(ImportProducts(context, productsJsonAsString));
            Console.WriteLine(ImportCategories(context, categoriesJsonAsString));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJsonAsString));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            //Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<UserInputDto> userDtos = JsonConvert.DeserializeObject<List<UserInputDto>>(inputJson);

            InitializeMapper();
            List<User> users = mapper.Map<List<User>>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<Product> products = mapper.Map<IEnumerable<Product>>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.ToList().Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDto> categoryDtos = 
                JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));

            InitializeMapper();
            IEnumerable<Category> categories = mapper.Map<IEnumerable<Category>>(categoryDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductInputDto> categoryProductDtos =
                JsonConvert.DeserializeObject<List<CategoryProductInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<CategoryProduct> categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductDtos);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.ToList().Count}";
        }

        public static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                });

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSetting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string productsAsJson = JsonConvert.SerializeObject(products, jsonSetting);

            return productsAsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                });

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string usersAsJson = JsonConvert.SerializeObject(usersWithSoldProducts, jsonSettings);

            return usersAsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = (c.CategoryProducts.Sum(cp => cp.Product.Price) / c.CategoryProducts.Count).ToString("f2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
                });

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string categoriesAsJson = JsonConvert.SerializeObject(categories, jsonSettings);

            return categoriesAsJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .ToList() // For judjde
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Count(),   

                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price,
                            })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count);

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = new 
            {
                UsersCount = usersWithProducts.Count(),
                Users = usersWithProducts
            };

            string usersWithProductAsJson = JsonConvert.SerializeObject(result, jsonSettings);

            return usersWithProductAsJson;
        }
    }
}