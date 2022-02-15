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

        enum textures
        {
            background = 0,
            background2 = 1,
            wallA = 2,
            wallB = 3,
            grass = 4,
            objective = 5,
            buttonOff = 6,
            buttonOn = 7,
            portalA = 8,
            portalB = 9,
            portalC = 10,
            portalD = 11,
            portalE = 12,
            portalF = 13,
            terminal = 14,
            boxInvalid = 15,
            boxValid = 16,
            boxNamed = 17,
            boxSarcina = 18,
            playerDown = 19,
            playerLeft = 20,
            playerRight = 21,
            playerUp = 22
        }

        public void Demo()
        {
                int k = 0;
                for (int i = 0; i < 18; ++i)
                    for (int j = 0; j < 12; ++j)
                    {
                        sprites[k % sprites.Count].Position = new Vector2f(40 * i, 40 * j);
                        window.Draw(sprites[k % sprites.Count]);
                        k++;
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
                    sprites[(int)textures.wallB].Position = new Vector2f(i * 40, j * 40);
                    window.Draw(sprites[(int)textures.wallB]);
                }
            }
        }

        public void DrawHint(int level)
        {
            text.FillColor = new Color(47, 79, 79);
            switch (level)
            {
                case 1:
                    text.DisplayedString = "Welcome";
                    text.Position = new Vector2f(20 * 20, 3 * 40);
                    window.Draw(text);
                    text.DisplayedString = "in tutorial";
                    text.Position = new Vector2f(20 * 20, 4 * 40);
                    window.Draw(text);
                    text.DisplayedString = "Move All boxes";
                    text.Position = new Vector2f(12 * 20, 7 * 40);
                    window.Draw(text);
                    text.DisplayedString = "to marked positions";
                    text.Position = new Vector2f(12 * 20, 8 * 40);
                    window.Draw(text);
                    break;
                case 2:
                    text.DisplayedString = "WOAH Portals?!";
                    text.Position = new Vector2f(15 * 20, 3 * 40);
                    window.Draw(text);
                    text.DisplayedString = "Let's check what";
                    text.Position = new Vector2f(15 * 20, 4 * 40);
                    window.Draw(text);
                    text.DisplayedString = "happens with box";
                    text.Position = new Vector2f(15 * 20, 5 * 40);
                    window.Draw(text);
                    text.DisplayedString = "inside it";
                    text.Position = new Vector2f(15 * 20, 6 * 40);
                    window.Draw(text);
                    break;
                case 3:
                    text.DisplayedString = "This grass looks";
                    text.Position = new Vector2f(15 * 20, 0 * 40);
                    window.Draw(text);
                    text.DisplayedString = "solid. Maybe this";
                    text.Position = new Vector2f(15 * 20, 1 * 40);
                    window.Draw(text);
                    text.DisplayedString = "funny terminal will";
                    text.Position = new Vector2f(15 * 20, 2 * 40);
                    window.Draw(text);
                    text.DisplayedString = "change it?";
                    text.Position = new Vector2f(15 * 20, 3 * 40);
                    window.Draw(text);
                    text.DisplayedString = "G on Box just like..";
                    text.Position = new Vector2f(15 * 20, 4 * 40);
                    window.Draw(text);
                   /* text.DisplayedString = "(G)rass...";
                    text.Position = new Vector2f(15 * 20, 5 * 40);
                    window.Draw(text); */
                    text.DisplayedString = "Button must be";
                    text.Position = new Vector2f(15 * 20, 7 * 40);
                    window.Draw(text);
                    text.DisplayedString = "connected to the";
                    text.Position = new Vector2f(15 * 20, 8 * 40);
                    window.Draw(text);
                    text.DisplayedString = "terminal";
                    text.Position = new Vector2f(15 * 20, 9 * 40);
                    window.Draw(text);
                    break;
            }
            text.FillColor = Color.Black;
        }

        public void DrawMainMenu(int active)
        {

            List<string> gui = new List<string>() { "Play", "Continue", "Tutorial", "About", "Progress", "Exit" };
            List<string> help = new List<string>() { "ESC - pause game", "Enter - accept option", "R - restart level", "WSAD, Arrows - move", "Controls:" };

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
                text.DisplayedString = "Congratulations!";
                text.Position = new Vector2f(45, 4 * 40 - 5);
                window.Draw(text);
                text.DisplayedString = "You've finished the game!";
                text.Position = new Vector2f(45, 5 * 40);
                window.Draw(text);
                text.DisplayedString = "The movements you made: " + score;
                text.Position = new Vector2f(45, 6 * 40);
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

        public void DrawCompleteTutorial()
        {
            DrawBackground();
            DrawTitle();

            text.DisplayedString = "Congratulation!";
            text.Position = new Vector2f(1 * 20, 4 * 40);
            window.Draw(text);
            text.DisplayedString = "Now try real levels in main menu";
            text.Position = new Vector2f(1 * 20, 5 * 40);
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

            text.DisplayedString = "Couldn't load your save";
            text.Position = new Vector2f(8 * 20 - 5, 4 * 40);
            window.Draw(text);
            text.DisplayedString = "Please start new level";
            text.Position = new Vector2f(8 * 20 - 5, 5 * 40);
            window.Draw(text);

            text.FillColor = new Color(0, 149, 179);

            text.DisplayedString = "Back to menu";
            text.Position = new Vector2f(720 / 2 - 137, 10 * 40);
            window.Draw(text);
            text.FillColor = Color.Black;
        }

        public void DrawPauseMenu(int active)
        {
            List<string> gui = new List<string>() { "Resume", "Restart", "Save and Menu", "Back to Menu" };
            

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
                    sprites[(int)textures.background].Position = new Vector2f(i * 40, j * 40);
                    window.Draw(sprites[0]);

                    List<int> idList = map.getSpritesId(i, j);

                    if( idList.Contains((int)textures.objective) && idList.Contains((int)textures.boxInvalid))
                    {
                        //idList.Remove((int)textures.objective);
                        idList.Remove((int)textures.boxInvalid);

                        idList.Add((int)textures.boxValid);
                    }

                    if (idList.Contains((int)textures.buttonOff) && (idList.Contains((int)textures.playerDown) ||
                                                                     idList.Contains((int)textures.playerUp) ||
                                                                     idList.Contains((int)textures.playerLeft) ||
                                                                     idList.Contains((int)textures.playerRight)))
                    {
                        idList.Remove((int)textures.buttonOff);
                        idList.Add((int)textures.buttonOn);
                    }

                    idList.Sort();
                    foreach (var id in idList)
                    {
                        int _id = (id < sprites.Count ? (id >= 0 ? id : 0) : 0);
                       
                        sprites[_id].Position = new Vector2f(i * 40, j * 40);
                        window.Draw(sprites[_id]);
                    }
                }
            }
        }

        public void DrawScore(int score, int level, bool cheater)
        {

            text.DisplayedString = "Moves: " + score;
            text.Position = new Vector2f(5, 11 * 40 - 15);
            window.Draw(text);
            text.DisplayedString = "Level: " + level;
            text.Position = new Vector2f(14 * 40 + ((level >= 10) ? -30 : -10), 11 * 40 - 15);
            window.Draw(text);
            if (cheater)
            {
                text.DisplayedString = "Cheater!";
                text.Position = new Vector2f(720 / 2 - 70, 11 * 40 - 15);
                window.Draw(text);
            }
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
                "background2.png",
                "wall_a.png",
                "wall_b.png",
                "grass.png",
                "objective.png",
                "button_off.png",
                "button_on.png",
                "portal_a.png",
                "portal_b.png",
                "portal_c.png",
                "portal_d.png",
                "portal_e.png",
                "portal_f.png",
                "terminal.png",
                "box_invalid.png",
                "box_valid.png",
                "box_named.png",
                "box_sarcina.png",
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
