using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> customStack;

        public int Count { get => customStack.Count; }

        public CustomStack(params T[] data)
        {
            customStack = new List<T>(data);
        }

        public void Push(T element)
        {
            customStack.Add(element);
        }

        public T Pop()
        {
            T elementToRemove = customStack[customStack.Count - 1];
            customStack.Remove(elementToRemove);
            return elementToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = customStack.Count - 1; i >= 0; i--)
            {
                yield return customStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
