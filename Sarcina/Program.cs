using System;
using Sarcina.Maps;
using Sarcina.Objects;
using System.Diagnostics;

using Sarcina.Managers;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Sarcina
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            GraphicManager graphicManager = new GraphicManager();

            RenderWindow window = new RenderWindow(new VideoMode(720, 480, 64), "Sarcina The Game", Styles.Default , new ContextSettings(24, 8, 16));
            window.SetFramerateLimit(60);
            window.KeyPressed += new EventHandler<KeyEventArgs>(gameManager.OnKeyPressed); // register key handler 
            graphicManager.AttachWindow(window);

            graphicManager.Demo();

        }



    }
}
