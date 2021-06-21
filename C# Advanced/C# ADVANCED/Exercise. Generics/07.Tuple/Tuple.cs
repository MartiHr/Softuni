using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T, V>
    {
        private T item1;
        private V item2;

        public Tuple(T input1, V input2)
        {
            item1 = input1;
            item2 = input2;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
