using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using Sarcina.Maps;


namespace Sarcina.Managers
{
    public class GraphicManager
    {

        private RenderWindow window;
        private List<Sprite> sprites = new List<Sprite>();
        private Font font;

        public static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }


        public GraphicManager(RenderWindow window)
        {
            this.window = window;
            LoadIcon();
            LoadSprites();
            LoadFont();
        }

        public void Demo()
        {

            float test = VideoMode.DesktopMode.Height / 40;
            CircleShape cs = new CircleShape(test * 2);
            cs.FillColor = Color.Green;
            window.SetActive();
            window.Closed += new EventHandler(OnClose);
            while (window.IsOpen)
            {

                window.DispatchEvents();

                window.Clear();
                int k = 0;
                for (int i = 0; i < 18; ++i)
                    for (int j = 0; j < 12; ++j)
                    {
                        sprites[k % sprites.Count].Position = new Vector2f(40 * j, 40 * i);
                        window.Draw(sprites[k % sprites.Count]);
                        k++;
                    }
                window.Display();
            }
        }


        public void DrawMainMenu()
        {
            Text text = new Text("", font);

            for(int i = 0; i<18; ++i)
            {
                for(int j = 0; j<12; ++j)
                {
                    sprites[1].Position = new Vector2f(i * 40, j * 40);
                    window.Draw(sprites[1]);
                }
            }
        }

        public void DrawAbout()
        {

        }

        public void DrawMap(Map map)
        {
            int height = map.Height;
            int width = map.Width;

            for(int i = 0; i<width; ++i)
            {
                for(int j = 0; j<height; ++j)
                {
                    List<int> idList = map.getSpritesId(i, j);
                    foreach (var id in idList)
                    {
                        int _id = (id < sprites.Count ? id : 0);
                        sprites[_id].Position = new Vector2f(i * 40, j * 40);
                        window.Draw(sprites[_id]);
                    }
                }
            }
        }

        public void DrawScore(int score, int level)
        {

        }

        public void AttachWindow(RenderWindow window)
        {
            this.window = window;
        }

        private void LoadSprites()
        {
            List<string> resources = new List<string>()
            {
                "background.png",
                "wall_a.png",
                "wall_b.png",
                "grass.png",
                "objective.png",
                "button_off.png",
                "button_on.png",
                "box_invalid.png",
                "box_valid.png",
                "box_sarcina.png",
                "portal_a.png",
                "portal_b.png",
                "portal_c.png",
                "portal_d.png",
                "portal_e.png",
                "portal_f.png",
                "terminal.png",
                "player_down.png",
                "player_left.png",
                "player_right.png",
                "player_up.png"

            };

            foreach (var res in resources)
            {

                Texture texture = new Texture("resources/" + res);
                Sprite sprite = new Sprite(texture);
                
                sprites.Add(sprite);

            }
        }

        private void LoadIcon()
        {
            Image image = new Image("resources/sarcina.png");

            Byte[] icon = new Byte[40 * 40 * 4];

            for (uint i = 0; i < 40; ++i)
            {
                for (uint j = 0; j < 40; ++j)
                {
                    Color tmp = image.GetPixel( i, j);
                    icon[(i + j * 40) * 4] = tmp.R;
                    icon[(i + j * 40) * 4 + 1] = tmp.G;
                    icon[(i + j * 40) * 4 + 2] = tmp.B;
                    icon[(i + j * 40) * 4 + 3] = tmp.A;
                }
            }

            window.SetIcon(40, 40, icon);

            image.Dispose();

        }

        private void LoadFont()
        {
            font = new Font("resources/VT323-regular.ttf");
        }

    }
}
