using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents) 
        {
            Documents = new List<string>(documents);
            Name = name;
        }

        public IReadOnlyCollection<string> Documents { get; set; }
      
        public string Name { get; set; }

        public string PrintInformatin()
        {
            return Name + string.Join(Environment.NewLine, Documents);
        }
    }
}
