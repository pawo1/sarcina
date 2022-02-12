using System;
using Sarcina.Objects;
using Sarcina.Maps;
using System.Diagnostics;

namespace Sarcina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameObject gameObject = new Player();
            Console.WriteLine(gameObject);

            Map map = new Map(3, 4);
        }
    }
}
