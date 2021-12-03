using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersXmlAsString = File.ReadAllText("Datasets/suppliers.xml");
            string partsXmlAsString = File.ReadAllText("Datasets/parts.xml");
            string carsXmlAsString = File.ReadAllText("Datasets/cars.xml");
            string customersXmlAsString = File.ReadAllText("Datasets/customers.xml");
            string salesXmlAsString = File.ReadAllText("Datasets/sales.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersXmlAsString));
            Console.WriteLine(ImportParts(context, partsXmlAsString));
            Console.WriteLine(ImportCars(context, carsXmlAsString));
            Console.WriteLine(ImportCustomers(context, customersXmlAsString));
            Console.WriteLine(ImportSales(context, salesXmlAsString));

            //Console.WriteLine(GetCarsWithDistance(context));
            //Console.WriteLine(GetCarsFromMakeBmw(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportPartDto[] importPartDtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            Part[] parts = mapper.Map<Part[]>(importPartDtos)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray(); 

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportCarDto[] importCarDtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            foreach (ImportCarDto carDto in importCarDtos)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                context.Cars.Add(car);

                foreach (var partDtoId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Find(partDtoId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar
                    {
                        Car = car,
                        Part = part
                    };

                    context.PartCars.Add(partCar);
                }
            }
            context.SaveChanges();

            return $"Successfully imported {importCarDtos.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportCustomerDto[] importCustomerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            Customer[] customers = mapper.Map<Customer[]>(importCustomerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);
            ImportSaleDto[] importCustomerDtos = (ImportSaleDto[])xmlSerializer.Deserialize(stringReader);

            InitializeMapper();
            Sale[] sales = mapper.Map<Sale[]>(importCustomerDtos)
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static void InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportCarsWithDistanceDto[] exportCarsWithDistanceDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance.ToString()
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, exportCarsWithDistanceDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMakeBmwDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportCarsFromMakeBmwDto[] carsFromMakeBmwDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarsFromMakeBmwDto
                {
                    Id = c.Id.ToString(),
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carsFromMakeBmwDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportLocalSuppliersDto[] exportLocalSuppliersDtos = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count.ToString()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, exportLocalSuppliersDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithTheirListOfPartsDto[]), xmlRootAttribute);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            ExportCarsWithTheirListOfPartsDto[] exportCarsWithTheirListOfPartsDtos = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithTheirListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString(),
                    Parts = c.PartCars.Select(c => c.Part)
                    .OrderByDescending(p => p.Price)
                    .Select(p => new PartDto
                    {
                        Name = p.Name,
                        Price = p.Price.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, exportCarsWithTheirListOfPartsDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]), xmlRootAttribute);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportTotalSalesByCustomerDto[] exportTotalSalesByCustomerDtos = context
            .Customers
            .ToArray()
            .Where(c => c.Sales.Count > 0)
            .Select(c => new ExportTotalSalesByCustomerDto
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales
                    .Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
            })
            .OrderByDescending(c => c.SpentMoney)
            .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, exportTotalSalesByCustomerDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSalesWithAppliedDiscountDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            ExportSalesWithAppliedDiscountDto[] exportSalesWithAppliedDiscountDtos = context
                .Sales
                .Select(s => new ExportSalesWithAppliedDiscountDto
                {
                    Car = new CarDto 
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                                          (s.Discount / 100  * (1 - (s.Discount / 100))))
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, exportSalesWithAppliedDiscountDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}