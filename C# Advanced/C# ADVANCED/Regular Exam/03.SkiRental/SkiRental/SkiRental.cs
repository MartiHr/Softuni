using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>(Capacity);
        }

        public void Add(Ski ski)
        {
            if (Capacity - Count > 0)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            foreach (var ski in data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    data.Remove(ski);
                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            foreach (var ski in data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    return ski;
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
