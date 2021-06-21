using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
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
