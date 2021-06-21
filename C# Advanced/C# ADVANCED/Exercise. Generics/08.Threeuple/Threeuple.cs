using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T, U, V>
    {
        public T Item1 { get; set; }
            
        public U Item2 { get; set; }

        public V Item3 { get; set; }


        public Threeuple(T input1, U input2, V input3)
        {
            Item1 = input1;
            Item2 = input2;
            Item3 = input3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
