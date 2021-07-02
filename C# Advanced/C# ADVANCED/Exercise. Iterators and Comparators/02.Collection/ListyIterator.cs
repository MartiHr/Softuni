using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> data = new List<T>();

        public int internalIndex { get; private set; }

        public ListyIterator(params T[] data)
        {
            this.data = new List<T>(data);
        }

        public bool HasNext()
        {
            return internalIndex < data.Count - 1;
        }

        public bool Move()
        {
            if (HasNext())
            {
                internalIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            Console.WriteLine(data[internalIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
