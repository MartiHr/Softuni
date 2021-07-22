using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine()
                    .Split(" ");
                string classType1 = pizzaInput[0].ToLower();
                string pizzaName = pizzaInput[1];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughInput = Console.ReadLine()
                      .Split(" ");
                string classType2 = doughInput[0].ToLower();
                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                double weight = double.Parse(doughInput[3]);

                if (classType2 == "dough")
                {
                    Dough dough = new Dough(flourType, bakingTechnique, weight);
                    pizza.Dough = dough;
                }

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = command
                        .Split(" ");
                    string classType3 = toppingInput[0].ToLower();
                    string toppingType = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);

                    if (classType3 == "topping")
                    {
                        Topping topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToping(topping);
                    }
                }

                pizza.TotalCalories += pizza.Dough.TotalCalories;

                foreach (var item in pizza.Toppings)
                {
                    pizza.TotalCalories += item.GetToppingCalories();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

