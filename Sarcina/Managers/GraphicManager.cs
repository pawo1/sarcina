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
        private Text text;

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
            text = new Text("", font, 50);
            text.Style = Text.Styles.Bold;
            text.FillColor = Color.Black;

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


        private void DrawTitle()
        {
            Text title = new Text("SARCINA", font, 150);
            title.Style = Text.Styles.Underlined | Text.Styles.Bold;
            title.Position = new Vector2f(8 * 20 - 9, -2 *20 );
            title.FillColor = new Color(222, 47, 62, 150);
            window.Draw(title);

        }

        private void DrawBackground()
        { 
            for (int i = 0; i < 18; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    sprites[2].Position = new Vector2f(i * 40, j * 40);
                    window.Draw(sprites[2]);
                }
            }
        }

        public void DrawMainMenu(int active)
        {

            List<string> gui = new List<string>() { "Play", "Continue", "About", "Progress", "Exit" };
            List<string> help = new List<string>() { "ESC - pasue game", "Enter - accept option", "R - restart level", "WSAD, Arrows - move", "Controls:" };

            DrawBackground();
            DrawTitle();

            for (int i = 0; i < gui.Count; ++i)
            {
                if (active == i)
                    text.FillColor = new Color(0, 149, 179);

                text.DisplayedString = gui[i];
                text.Position = new Vector2f(720 / 2, 7 * 20 + i * 40);
                window.Draw(text);
                text.FillColor = Color.Black;
            }

            text.CharacterSize = 38;
            text.FillColor = new Color(47, 79, 79);
            for (int i = 0; i < help.Count; ++i) {
                text.DisplayedString = help[i];
                text.Position = new Vector2f(5, 21 * 20 - 7 - 38 * i);
                window.Draw(text);
            }
            text.CharacterSize = 50;
            text.FillColor = Color.Black;
        }

        public void DrawAbout()
        {

            DrawBackground();
            DrawTitle();

            List<string> list = new List<string>() { "Coders: Piotr \"Darth\" Marciniak", "      & Paweł \"Pawo\"  Sobczak", "Concept Art: Darth", "Level Design: Pawo & Darth" };

            for(int i = 0; i < list.Count; ++i)
            {
                text.Position = new Vector2f(3 * 20 - 5, (5 + i) * 40);
                text.DisplayedString = list[i];
                window.Draw(text);
            }

            text.FillColor = new Color(0, 149, 179);
            text.DisplayedString = "Back to menu";
            text.Position = new Vector2f(720 / 2 - 132, 10 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;

        }

        public void DrawProgressMenu(int active, int score, int currentLevel, int totalLevel)
        {
            DrawBackground();
            DrawTitle();
            text.CharacterSize = 48;
            
            if(currentLevel > totalLevel)
            {
                text.DisplayedString = "Congratulations! You've finished the game!";
                text.Position = new Vector2f(45, 5 * 40);
                window.Draw(text);
                text.DisplayedString = "The movements you made: " + score;
                text.Position = new Vector2f(45, 7 * 40);
                window.Draw(text);
            } 
            else
            {
                text.DisplayedString = "You've completed " + (currentLevel-1) + " out of " +totalLevel +" levels";
                text.Position = new Vector2f(((currentLevel - 1 > 10) ? 1 * 10 : 1 * 10 + 13), 5 * 40);
                window.Draw(text);
                text.DisplayedString = "The movements you made: " + score;
                text.Position = new Vector2f(((currentLevel - 1 > 10) ? 1 * 10 : 1 * 10 + 13), 7 * 40);
                window.Draw(text);
            }

            if(active == 0)
                text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Reset progress";
            text.Position = new Vector2f(720 / 2 - 150, 9 * 40);
            window.Draw(text);

            text.FillColor = Color.Black;

            if (active == 1)
                text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Back to menu";
            text.Position = new Vector2f(720 / 2 - 137, 10 * 40);
            window.Draw(text);

            text.FillColor = Color.Black;
            text.CharacterSize = 50;
        }

        public void DrawHardResetMenu(int active)
        {
            DrawBackground();
            DrawTitle();

            text.DisplayedString = "Are you Sure you want to reset?";
            text.Position = new Vector2f(2 * 20 - 19, 5 * 40);
            window.Draw(text);
            text.DisplayedString = "This operation cannot be undone.";
            text.Position = new Vector2f(2 * 20 - 19, 6 * 40);
            window.Draw(text);

            if(active == 0)
                text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Yes";
            text.Position = new Vector2f(720 / 2 - 21, 9 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;

            if (active == 1)
                text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "No";
            text.Position = new Vector2f(720 / 2 - 17, 10 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;

        }

        public void DrawCompleteMenu()
        {
            DrawBackground();
            DrawTitle();

            text.DisplayedString = "Operation Compelte";
            text.Position = new Vector2f(9 * 20, 6 * 40);
            window.Draw(text);

            text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Back to menu";
            text.Position = new Vector2f(720 / 2 - 137, 10 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;
        }


        public void DrawNoSaveInfo()
        {
            DrawBackground();
            DrawTitle();

            text.DisplayedString = "Couldn't load save file";
            text.Position = new Vector2f(9 * 20, 6 * 40);
            window.Draw(text);
            text.DisplayedString = "Start new level";
            text.Position = new Vector2f(9 * 20, 7 * 40);
            window.Draw(text);

            text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Back to menu";
            text.Position = new Vector2f(720 / 2 - 137, 10 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;
        }

        public void DrawPauseMenu(int active)
        {
            List<string> gui = new List<string>() { "Resume", "Restart", "Save and Exit", "Exit" };
            

            DrawBackground();
            DrawTitle();

            for (int i = 0; i < gui.Count; ++i)
            {
                if (active == i)
                    text.FillColor = new Color(0, 149, 179);

                text.DisplayedString = gui[i];
                text.Position = new Vector2f(720 / 2, 7 * 20 + i * 40);
                window.Draw(text);
                text.FillColor = Color.Black;
            }

        }

        public void DrawMap(Map map)
        {
            int height = map.Height;
            int width = map.Width;

            for(int i = 0; i<width; ++i)
            {
                for(int j = 0; j<height; ++j)
                {
                    sprites[0].Position = new Vector2f(i * 40, j * 40);
                    window.Draw(sprites[0]);

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
            level = 10;

            text.DisplayedString = "Moves: " + score;
            text.Position = new Vector2f(5, 11 * 40 - 15);
            window.Draw(text);
            text.DisplayedString = "Level: " + level;
            text.Position = new Vector2f(14 * 40 + ((level >= 10) ? -30 : -10), 11 * 40 - 15);
            window.Draw(text);
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
