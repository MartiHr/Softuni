﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine($"I'm {nameof(Square)}");
        }
    }
}
