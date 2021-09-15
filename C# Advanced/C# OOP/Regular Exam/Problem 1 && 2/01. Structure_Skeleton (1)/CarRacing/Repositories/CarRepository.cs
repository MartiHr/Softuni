using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        public CarRepository()
        {
            Models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models { get; private set; }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }

            List<ICar> clone = Models.ToList();
            clone.Add(model);

            Models = clone;
        }

        public ICar FindBy(string property)
        {
            foreach (var model in Models)
            {
                if (model.VIN == property)
                {
                    return model;
                }
            }

            return null;
        }

        public bool Remove(ICar model)
        {
            List<ICar> clone = Models.ToList();

            bool success = clone.Remove(model);

            if (success)
            {
                Models = clone;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
