using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
            set
            {
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                if (value < 0)
                {
                    value = 0;
                }

                health = value;
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                
                armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            Armor -= hitPoints;
            hitPoints -= Armor;

            if (hitPoints > 0)
            {
                Health -= hitPoints;

                if (Health == 0)
                {
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}