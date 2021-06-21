using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> box; 

        public int Count { get => box.Count; }

        public Box()
        {
            box = new List<T>();
        }

        public void Add(T element)
        {
            box.Add(element);
        }

        public T Remove()
        {
            T lastElement = box[Count - 1];
            box.Remove(lastElement);
            
            return lastElement;
        }
    }
}
