using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while(heroes.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        Druid druid = new Druid(heroName);
                        heroes.Add(druid);
                        break;
                    case "Paladin":
                        Paladin paladin = new Paladin(heroName);
                        heroes.Add(paladin);
                        break;
                    case "Rogue":
                        Rogue rogue = new Rogue(heroName);
                        heroes.Add(rogue);
                        break;
                    case "Warrior":
                        Warrior warrior = new Warrior(heroName);
                        heroes.Add(warrior);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int totalAllyPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalAllyPower += hero.Power;
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (totalAllyPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
