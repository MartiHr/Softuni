using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public T Value { get; }

        public List<T> ListOfT { get; }


        public Box(T value)
        {
            Value = value;
        }

        public Box(List<T> elementsList)
        {
            ListOfT = elementsList;
        }


        public int ComparisonByValue(List<T> list, T comparisonElement)
        {
            int count = 0;
            
            foreach (var element in list)
            {
                if (element.CompareTo(comparisonElement) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public void SwapElements(List<T> elements, int firstIndex, int secondIndex)
        {
            T firstItem = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstItem;  
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var element in ListOfT)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }

            return sb.ToString();
        }
    }
}
