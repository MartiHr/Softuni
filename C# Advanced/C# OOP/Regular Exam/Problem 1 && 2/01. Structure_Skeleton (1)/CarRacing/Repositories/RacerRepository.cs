using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        public RacerRepository()
        {
            Models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models { get; private set; }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            List<IRacer> clone = Models.ToList();
            clone.Add(model);
        }

        public IRacer FindBy(string property)
        {
            foreach (var model in Models)
            {
                if (model.Username == property)
                {
                    return model;
                }
            }

            return null;
        }

        public bool Remove(IRacer model)
        {
            List<IRacer> clone = Models.ToList();

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
