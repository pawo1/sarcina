using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;

using System.Threading;


namespace Sarcina.Managers
{
    public class GraphicManager
    {

        private RenderWindow window;

        public GraphicManager()
        {

        }

        public GraphicManager(RenderWindow window)
        {
            this.window = window;
        }

        public void AttachWindow(RenderWindow window)
        {
            this.window = window;
        }

        public void Demo()
        {
            
            float test = VideoMode.DesktopMode.Height / 40;
            CircleShape cs = new CircleShape(test*2);
            cs.FillColor = Color.Green;
            window.SetActive();
            window.Closed += new EventHandler(OnClose);
            float i=0, j=0;
            while (window.IsOpen)
            {
                
                j += 10;

                window.DispatchEvents();

                window.Clear();
              /*  for (int k = 0; k < 5; ++k)
                {
                    i += test * 8;
                    cs.Position = new SFML.System.Vector2f(i % VideoMode.DesktopMode.Width, j % VideoMode.DesktopMode.Height);
                    window.Draw(cs);
                } */
                
                window.Display();
               // Thread.Sleep(300);
            }
        }

        public static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

    }
}
