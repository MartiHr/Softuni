using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleAndMoney = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsAndPrices= Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach (var person in peopleAndMoney)
                {
                    string[] elements = person
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = elements[0];
                    decimal money = decimal.Parse(elements[1]);

                    Person currentPerson = new Person(name, money);
                    people.Add(currentPerson);
                }

                foreach (var product in productsAndPrices)
                {
                    string[] elements = product
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = elements[0];
                    decimal cost = decimal.Parse(elements[1]);

                    Product currentProduct = new Product(name, cost);
                    products.Add(currentProduct);
                }

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] elements = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = elements[0];
                    string productName = elements[1];

                    foreach (var person in people)
                    {
                        if (person.Name == personName)
                        {
                            foreach (var product in products)
                            {
                                if (product.Name == productName)
                                {
                                    if (person.Money >= product.Cost)
                                    {
                                        person.BagOfProducts.Add(product);
                                        person.ReduceMoney(product.Cost);
                                        Console.WriteLine($"{person.Name} bought {product.Name}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{personName} can't afford {productName}");
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            
            foreach (var person in people)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
