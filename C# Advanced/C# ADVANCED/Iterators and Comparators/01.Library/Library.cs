using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> Books { get; }

        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                yield return Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
