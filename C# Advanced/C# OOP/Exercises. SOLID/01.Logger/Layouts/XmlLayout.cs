using _01.Logger.Interfaces;
using System;

namespace _01.Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template
            => 
            $"<log>{Environment.NewLine}" +
            $"    <date>{{0}}</date>{Environment.NewLine}" +
            $"    <level>{{1}}</level>{Environment.NewLine}" +
            $"    <message>{{2}}</message>{Environment.NewLine}" +
            $"</log>";
    }
}
