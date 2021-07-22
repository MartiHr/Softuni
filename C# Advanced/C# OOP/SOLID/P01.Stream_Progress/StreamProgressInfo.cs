using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private Data data;
        
        public StreamProgressInfo(Data data)
        {
            this.data = data;
        }

        public int CalculateCurrentPercent()
        {
            return (this.data.BytesSent * 100) / this.data.Length;
        }
    }
}
