using System;
using Sarcina.Maps;
using Sarcina.Objects;
using System.Diagnostics;

using Sarcina.Managers;



namespace Sarcina
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Run();
        }
    }
}
