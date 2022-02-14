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
        
        private int menuOption;
        private int maxOption;

        private List<Keyboard.Key> secretCodes;
        private Clock secretClock;
        private Clock keyClock;

        enum gameState
        {
            MainMenu = 1,
            About,
            Progress,
            HardReset,
            Complete,
            Save,
            Pause,
            Continue,
            NoSave,
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
            menuOption = 0;
            maxOption = 4;
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
                        graphicManager.DrawMainMenu(menuOption);
                        break;

                    case gameState.About:
                        graphicManager.DrawAbout();
                        break;

                    case gameState.Progress:
                        graphicManager.DrawProgressMenu(menuOption, playerInfo.TotalScore, playerInfo.CurrentLevel, playerInfo.TotalLevels);
                        break;

                    case gameState.HardReset:
                        graphicManager.DrawHardResetMenu(menuOption);
                        break;

                    case gameState.Complete:
                        graphicManager.DrawCompleteMenu();
                        break;

                    case gameState.Pause:
                        graphicManager.DrawPauseMenu(menuOption);
                        break;

                    case gameState.Continue:
                        try
                        {
                            LoadMap("continue.json");
                            State = gameState.Level;
                            ConnectLevel();
                        }
                        catch(Exception)
                        {
                            State = gameState.NoSave;
                        }
                        break;

                    case gameState.NoSave:
                        graphicManager.DrawNoSaveInfo();
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
            if (keyClock.ElapsedTime >= Time.FromMilliseconds(100))
            {
                switch (e.Code)
                {
                    case Keyboard.Key.Up:
                    case Keyboard.Key.W:
                        menuOption = (menuOption > 0 ? menuOption-1 : 0);
                        break;
                    case Keyboard.Key.Down:
                    case Keyboard.Key.S:
                        menuOption = (menuOption < maxOption ? menuOption+1 : maxOption);
                        break;
                    case Keyboard.Key.Enter:
                        switch(State)
                        {
                            case gameState.MainMenu:
                                OnConfirmMainMenu();
                                break;
                            case gameState.Complete:
                            case gameState.About:
                            case gameState.NoSave:
                                State = gameState.MainMenu;
                                maxOption = 4;
                                break;
                            case gameState.Progress:
                                OnConfirmProgress();
                                break;
                            case gameState.Pause:
                                OnConfirmPause();
                                break;
                            case gameState.HardReset:
                                OnConfirmHardReset();
                                break;
                        }
                        break;
                }
                keyClock.Restart();
            }
        }

        public void OnConfirmMainMenu()
        {


            switch(menuOption)
            {
                case 0: // play
                    playerInfo.ResetLevel();
                    State = gameState.LoadLevel;
                    ConnectLevel();
                    break;
                case 1: // continue
                    State = gameState.Continue;
                    maxOption = 0;
                    menuOption = 0;
                    break;
                case 2: // about
                    State = gameState.About;
                    maxOption = 0;
                    menuOption = 0;
                    break;
                case 3: // progress
                    State = gameState.Progress;
                    menuOption = 1;
                    maxOption = 1;
                    break;
                case 4: // exit
                    window.Close();
                    break;
            }
        }
        
        public void OnConfirmProgress()
        {
            switch(menuOption)
            {
                case 0: //reset
                    State = gameState.HardReset;
                    menuOption = 1;
                    maxOption = 1;
                    break;
                case 1:
                    State = gameState.MainMenu;
                    menuOption = 0;
                    maxOption = 4;
                    break;
            }
        }

        public void OnConfirmHardReset()
        {
            switch (menuOption)
            {
                case 0: // yes
                    playerInfo.HardReset();
                    State = gameState.Complete;
                    menuOption = 0;
                    maxOption = 0;
                    break;
                case 1:
                    State = gameState.MainMenu;
                    menuOption = 0;
                    maxOption = 4;
                    break;
            }
        }

        public void OnConfirmPause()
        {
            switch (menuOption)
            {
                case 0: // resume
                    State = gameState.Level;
                    ConnectLevel();
                    break;
                case 1: // restart
                    State = gameState.Restart;
                    ConnectLevel();
                    break;
                case 2: // save and exit
                    SaveMap("continue.json");
                    SavePlayerInfo();
                    State = gameState.Complete;
                    maxOption = 0;
                    menuOption = 0;
                    break;
                case 3: // exit
                    State = gameState.MainMenu;
                    RestoreMap();
                    playerInfo.ResetLevel();
                    menuOption = 0;
                    maxOption = 4;
                    break;
            }
        }
        
        private void ConnectLevel()
        {
            window.KeyPressed += keyLevelHandler;
            window.KeyPressed -= keyMenuHandler;
        }

        private void ConnectMenu()
        {
            window.KeyPressed -= keyLevelHandler;
            window.KeyPressed += keyMenuHandler;
        }

        public void OnKeyPressedLevel(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            VectorObject vector = new VectorObject(0, 0);
            int moves;

            if (keyClock.ElapsedTime >= Time.FromMilliseconds(70))
            {
                switch (e.Code)
                {
                    case Keyboard.Key.Escape:
                        State = gameState.Pause;
                        maxOption = 3;
                        menuOption = 0;
                        ConnectMenu();
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
