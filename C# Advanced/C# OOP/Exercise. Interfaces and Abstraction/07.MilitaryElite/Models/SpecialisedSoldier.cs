using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SoldierCorpsEnum Corps { get; set; }

        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, SoldierCorpsEnum corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
    }   
}
