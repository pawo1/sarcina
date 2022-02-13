using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

using Sarcina.CustomSerializators;
using Sarcina.Progress;
using Sarcina.Maps;
using Sarcina.Objects;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Sarcina.Managers
{
    public class GameManager
    {
        public Map map;
        private Map mapRestorationBuffer;
        private Dictionary<string, GameObjectProps> dictBuffer;
        private GraphicManager graphicManager;
        private RenderWindow window;
        private EventHandler<KeyEventArgs> keyLevelHandler;
        private EventHandler<KeyEventArgs> keyMenuHandler;

        private PlayerInfo playerInfo;

        private List<Keyboard.Key> secretCodes;
        private Clock secretClock;
        private Clock keyClock;

        enum gameState
        {
            MainMenu = 1,
            About,
            Progress,
            Save,
            Pause,
            Continue,
            LoadLevel,
            Level,
            NextLevel,
            Restart,
            Exit
        }

        gameState State;


        public GameManager()
        {
            keyClock = new Clock();
            secretClock = new Clock();
            secretCodes = new List<Keyboard.Key>();

            
            window = new RenderWindow(new VideoMode(720, 480, 64), "Sarcina The Game", Styles.Default, new ContextSettings(24, 8, 16));
            window.SetFramerateLimit(60);

            keyLevelHandler = new EventHandler<KeyEventArgs>(this.OnKeyPressedLevel); // register key handler 
            keyMenuHandler = new EventHandler<KeyEventArgs>(this.OnKeyPressedMenu); // register key handler 

            window.Closed += new EventHandler(GraphicManager.OnClose);
            graphicManager = new GraphicManager(window);

            LoadPlayerInfo();


            State = gameState.MainMenu;
            window.KeyPressed += keyMenuHandler;
        }




        public void Run()
        {

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                switch(State)
                {
                    case gameState.MainMenu:
                        graphicManager.DrawMainMenu();
                        break;

                    case gameState.About:
                        graphicManager.DrawAbout();
                        break;



                    case gameState.LoadLevel:
                        if (playerInfo.CurrentLevel > playerInfo.TotalLevels)
                            State = gameState.About;
                        else
                        {
                            LoadMap("levels/level" + playerInfo.CurrentLevel + ".json");
                            State = gameState.Level;
                        }
                        break;

                    case gameState.Level:
                        graphicManager.DrawMap(map);
                       graphicManager.DrawScore(playerInfo.Score, playerInfo.CurrentLevel);
                        break;

                    case gameState.NextLevel:
                        playerInfo.NextLevel();
                        State = gameState.LoadLevel;
                        break;

                    case gameState.Restart:
                        RestoreMap();
                        playerInfo.ResetLevel();
                        State = gameState.Level;
                        break;


                    case gameState.Exit:
                        window.Close();
                        break;
                }
                window.Display();
            }
            SavePlayerInfo();
            if(map is not null)
                SaveMap("continue.json");
        }

        public void OnKeyPressedMenu(object sender, KeyEventArgs e)
        {

        }


        public void OnKeyPressedLevel(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            VectorObject vector = new VectorObject(0, 0);
            int moves;

            if (keyClock.ElapsedTime >= Time.FromMilliseconds(100))
            {
                
                Console.WriteLine(e.Code);
                switch (e.Code)
                {
                    case Keyboard.Key.Escape:
                        window.Close();
                        break;

                    case Keyboard.Key.Up:
                        


                        // stuff for secrets
                        if(secretClock.ElapsedTime > Time.FromSeconds(3))
                        {
                            secretClock.Restart();
                            secretCodes.Clear();
                        }
                        secretCodes.Add(Keyboard.Key.Up);

                        // move stuff
                        vector.X = 0;
                        vector.Y = 1;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                State = gameState.NextLevel;
                            }
                        }

                        break;
                    case Keyboard.Key.Down:
                        secretCodes.Add(Keyboard.Key.Down);

                        // move stuff
                        vector.X = 0;
                        vector.Y = -1;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                State = gameState.NextLevel;
                            }
                        }
                        break;
                    case Keyboard.Key.Left:
                        secretCodes.Add(Keyboard.Key.Left);

                        // move stuff
                        vector.X = -1;
                        vector.Y = 0;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                State = gameState.NextLevel;
                            }
                        }

                        break;
                    case Keyboard.Key.Right:
                        secretCodes.Add(Keyboard.Key.Right);

                        // move stuff
                        vector.X = 1;
                        vector.Y = 0;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            playerInfo.AddMove(moves);
                            if(map.IsWon())
                            {
                                State = gameState.NextLevel;
                            }
                        }
                        break;

                    case Keyboard.Key.R:
                        secretCodes.Clear(); // key not from secret
                        State = gameState.Restart;
                        break;

                    case Keyboard.Key.B:
                        secretCodes.Add(Keyboard.Key.B);
                        break;

                    case Keyboard.Key.A:
                        secretCodes.Add(Keyboard.Key.A);
                        if(secretClock.ElapsedTime <= Time.FromSeconds(6))
                        {
                            CheckKonami(new List<Keyboard.Key>(secretCodes.TakeLast(10)));
                        }
                        break;
                }

                keyClock.Restart();
            }

               
        }

        public void LoadMap(string path)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = File.ReadAllText(path);
            map = JsonSerializer.Deserialize<Map>(json, settings);
            mapRestorationBuffer = CopyMap(map);
            dictBuffer = CopyDict(GameObject.GetDictionary());
        }

        public void SaveMap(string path)
        {
            File.WriteAllText(path, map.GetJson());
        }

        public void RestoreMap()
        {
            map = CopyMap(mapRestorationBuffer);
            GameObject.UpdateDictionary(CopyDict(dictBuffer));
        }


        private void LoadPlayerInfo()
        {
            try
            {
                string jsonRead = File.ReadAllText("PlayerInfo.json");
                playerInfo = JsonSerializer.Deserialize<PlayerInfo>(jsonRead);
            }
            catch (Exception)
            {
                playerInfo = new PlayerInfo();
            }

        }

        private void SavePlayerInfo()
        {
                string json = JsonSerializer.Serialize<PlayerInfo>(playerInfo);
                File.WriteAllText("PlayerInfo.json", json);
            
        }

        private void CheckKonami(List<Keyboard.Key> secretCodes)
        {
            if(secretCodes[0] == Keyboard.Key.Up && secretCodes[1] == Keyboard.Key.Up &&
                secretCodes[2] == Keyboard.Key.Down && secretCodes[3] == Keyboard.Key.Down &&
                secretCodes[4] == Keyboard.Key.Left && secretCodes[5] == Keyboard.Key.Right &&
                secretCodes[6] == Keyboard.Key.Left && secretCodes[7] == Keyboard.Key.Right &&
                secretCodes[8] == Keyboard.Key.B && secretCodes[9] == Keyboard.Key.A)
            {
                Console.WriteLine("You activated my trap CARD!");
            }
        }

        private  Map CopyMap(Map original)
        {
            int height = original.Height;
            int width = original.Width;

            Map copy = new Map(height, width);

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    foreach (GameObject obj in original.Grid[i][j])
                    {
                        copy.Grid[i][j].Add(obj.ShallowCopy());
                    }
                }
            }

            return copy;
        }

        private  Dictionary<string, GameObjectProps> CopyDict(Dictionary<string, GameObjectProps> original)
        {
            Dictionary<string, GameObjectProps> copy = new Dictionary<string, GameObjectProps>();
            copy = original.ToDictionary(entry => entry.Key, entry => (GameObjectProps)entry.Value.Clone()); // deep copy
            return copy; 
        }



    }
}
