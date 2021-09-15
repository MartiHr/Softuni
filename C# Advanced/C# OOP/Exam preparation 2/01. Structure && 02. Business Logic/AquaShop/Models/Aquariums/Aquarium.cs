using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium
            (string name,
            int capacity,
            int comfort,
            ICollection<IDecoration> decorations,
            ICollection<IFish> fish)
        {
            Name = name;
            Capacity = capacity;
            Comfort = comfort;
            Decorations = decorations;
            Fish = fish;
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity; 
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                    
                capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                return decorations.Sum(x => x.Comfort);
            }
            private set
            {
                comfort = value;
            }
        }

        public ICollection<IDecoration> Decorations { get => decorations; private set => decorations = value; }

        public ICollection<IFish> Fish { get => fish; private set => fish = value; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (capacity > 0)
            {
                Fish.Add(fish);
                capacity--;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {

        }

        public bool RemoveFish(IFish fish)
        {
            throw new NotImplementedException();
        }
    }
}
