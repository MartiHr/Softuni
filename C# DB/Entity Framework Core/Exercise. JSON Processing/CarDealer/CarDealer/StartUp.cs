using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext contex = new CarDealerContext();
            contex.Database.EnsureDeleted();
            contex.Database.EnsureCreated();

            string suppliersJsonAsString = File.ReadAllText("Datasets/suppliers.json");
            string partsJsonAsString = File.ReadAllText("Datasets/parts.json");
            string carsJsonAsString = File.ReadAllText("Datasets/cars.json");
            string customersJsonAsString = File.ReadAllText("Datasets/customers.json");
            string salesJsonAsString = File.ReadAllText("Datasets/sales.json");

            Console.WriteLine(ImportSuppliers(contex, suppliersJsonAsString));
            Console.WriteLine(ImportParts(contex, partsJsonAsString));
            Console.WriteLine(ImportCars(contex, carsJsonAsString));
            Console.WriteLine(ImportCustomers(contex, customersJsonAsString));
            Console.WriteLine(ImportSales(contex, salesJsonAsString));

            //Console.WriteLine(GetOrderedCustomers(contex));
            //Console.WriteLine(GetCarsFromMakeToyota(contex));
            //Console.WriteLine(GetLocalSuppliers(contex));
            //Console.WriteLine(GetCarsWithTheirListOfParts(contex));
            //Console.WriteLine(GetTotalSalesByCustomer(contex));
            Console.WriteLine(GetSalesWithAppliedDiscount(contex));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierInputDto> supplierDtos =
                JsonConvert.DeserializeObject<IEnumerable<SupplierInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<Supplier> suppliers = mapper.Map<IEnumerable<Supplier>>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IEnumerable<PartInputDto> partDtos =
                JsonConvert.DeserializeObject<IEnumerable<PartInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<Part> parts = mapper.Map<IEnumerable<Part>>(partDtos)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<CarInputDto[]>(inputJson);

            foreach (var ImportCarsDTO in carsDto)
            {
                Car car = new Car
                {
                    Make = ImportCarsDTO.Make,
                    Model = ImportCarsDTO.Model,
                    TravelledDistance = ImportCarsDTO.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in ImportCarsDTO.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }
            context.SaveChanges();

            return $"Successfully imported {carsDto.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<CustomerInputDto> customerDtos =
                JsonConvert.DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<Customer> customers = mapper.Map<IEnumerable<Customer>>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<SaleInputDto> saleDtos = JsonConvert.DeserializeObject<IEnumerable<SaleInputDto>>(inputJson);

            InitializeMapper();
            IEnumerable<Sale> sales = mapper.Map<IEnumerable<Sale>>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static void InitializeMapper()
        {
            var mapperConfiguariton = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfiguariton);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                 {
                     c.Name,
                     BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                     c.IsYoungDriver
                 });

            string orderedCustomersAsJson = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);

            return orderedCustomersAsJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                });

            string toyotaCarsAsJson = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return toyotaCarsAsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                });

            string localSuppliersAsJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return localSuppliersAsJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })

                });

            string carsWithPartsAsJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            return carsWithPartsAsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars);

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                { 
                    NamingStrategy = new CamelCaseNamingStrategy() 
                }
            };

            string customersAsJson = JsonConvert.SerializeObject(customers, jsonSerializerSettings);

            return customersAsJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100))).ToString("f2")
                })
                .Take(10);

            string salesWithDiscountAsJson = JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);

            return salesWithDiscountAsJson;
        }
    }
}