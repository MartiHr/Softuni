using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    public interface ILogFile
    {
        void Write(string message);

        public int Size { get; }
    }
}
