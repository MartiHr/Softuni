using _07.MilitaryElite.Models;
using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        public List<Repair> Repairs { get; set; }
    }
}
