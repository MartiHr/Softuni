using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public void AddPokemons(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void PokemonsLose10Health()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public bool HasAPokemonOfTheType(string element)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Element == element)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
