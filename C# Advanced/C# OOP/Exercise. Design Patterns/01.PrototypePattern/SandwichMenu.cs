using System.Collections.Generic;

namespace _01.PrototypePattern
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();
        
        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set => sandwiches.Add(name, value);
        }
    }
}
