using System;
using WmiParser;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new Parser();
            p.Parse("", 1);
            Console.WriteLine("Hello World!");
        }
    }
}
