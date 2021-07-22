using System;
using System.Linq;

namespace _03.Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            
            return $"Calling... {number}";
        }
    }
}
