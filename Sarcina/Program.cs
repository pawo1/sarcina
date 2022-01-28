using System;
using Sarcina.Objects;

namespace Sarcina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameObject gameObject = new Player();
            Console.WriteLine(gameObject);

            Map map = new Map(5, 5);
        }
    }
}
