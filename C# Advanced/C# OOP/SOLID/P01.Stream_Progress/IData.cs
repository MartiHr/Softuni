using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IData
    {
        public int BytesSent { get; }

        public int Length { get; }
    }
}
