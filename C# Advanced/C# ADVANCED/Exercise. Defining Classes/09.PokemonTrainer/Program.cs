using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;

            HashSet<Trainer> trainers = new HashSet<Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = elements[0];
                string pokemonName = elements[1];
                string pokemonElement = elements[2];
                int pokemonHealth = int.Parse(elements[3]);

                Pokemon currentPokemon = new Pokemon
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                Trainer currentTrainer = new Trainer
                {
                    Name = trainerName
                };

                bool trainerExists = false;

                foreach (var trainer in trainers)
                {
                    if (trainer.Name == currentTrainer.Name)
                    {
                        trainer.AddPokemons(currentPokemon);
                        trainerExists = true;
                        break;
                    }
                }

                if (!trainerExists)
                {
                    trainers.Add(currentTrainer);
                    currentTrainer.AddPokemons(currentPokemon);
                }
            }

            string command2;

            while ((command2 = Console.ReadLine()) != "End")
            {
                switch (command2)
                {
                    case "Fire":
                        ApplyCommand2(trainers, command2);
                        break;
                    case "Water":
                        ApplyCommand2(trainers, command2);
                        break;
                    case "Electricity":
                        ApplyCommand2(trainers, command2);
                        break;
                }
            }

            List<Trainer> sortedTrainers = trainers
                .OrderByDescending(x => x.NumberOfBadges)
                .ToList();

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine(trainer);
            }
        }

        private static void ApplyCommand2(HashSet<Trainer> trainers, string command2)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.HasAPokemonOfTheType(command2))
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    trainer.PokemonsLose10Health();

                    trainer.Pokemons = trainer.Pokemons
                        .Where(x => x.Health > 0)
                        .ToList();
                }
            }
        }
    }
}
