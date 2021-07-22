using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public abstract class Data : IData
    {
        public Data(int bytesSent, int length)
        {
            BytesSent = bytesSent;
            Length = length;
        }

        public int BytesSent { get; }

        public int Length { get; }
    }
}
