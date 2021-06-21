using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public T Value { get; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}
