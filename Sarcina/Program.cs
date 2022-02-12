using System;
using Sarcina.Objects;
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

            Debug.WriteLine("Down:");
            map.Update(new System.Numerics.Vector2(0, -1));
            Debug.WriteLine("Up:");
            map.Update(new System.Numerics.Vector2(0, 1));
            Debug.WriteLine("Right:");
            map.Update(new System.Numerics.Vector2(1, 0));
            Debug.WriteLine("Down:");
            map.Update(new System.Numerics.Vector2(-1, 0));
        }
    }
}
