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
        private PlayerInfo tutorialInfo;
        private Player prototype;
        private int menuOption;
        private bool cheater = false;

        private List<Keyboard.Key> secretCodes;
        private Clock secretClock;
        private Clock keyClock;

        enum GameState
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
            LoadTutorial,
            Tutorial,
            NextTutorial,
            RestartTutorial,
            CompleteTutorial,
            LoadLevel,
            Level,
            NextLevel,
            Restart,
            Demo,
            Exit
        }

        
        enum MaxOption
        {
            MainMenu = 5,
            About = 0,
            Complete = 0,
            NoSave = 0,
            Progress = 1,
            HardReset = 1,
            Pause = 3

        }

        enum PlayerTexture
        {
            playerDown = 19,
            playerLeft = 20,
            playerRight = 21,
            playerUp = 22
        }

        GameState State;


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
            prototype = new Player();

            State = GameState.MainMenu;
            menuOption = 0;
            window.KeyPressed += keyMenuHandler;
        }




        public void Run()
        {

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                switch (State)
                {
                    case GameState.MainMenu:
                        graphicManager.DrawMainMenu(menuOption);
                        break;

                    case GameState.Demo:
                        graphicManager.Demo();
                        break;

                    case GameState.About:
                        graphicManager.DrawAbout();
                        break;

                    case GameState.Progress:
                        graphicManager.DrawProgressMenu(menuOption, playerInfo.TotalScore, playerInfo.CurrentLevel, playerInfo.TotalLevels);
                        break;

                    case GameState.HardReset:
                        graphicManager.DrawHardResetMenu(menuOption);
                        break;

                    case GameState.Complete:
                        graphicManager.DrawCompleteMenu();
                        break;

                    case GameState.Pause:
                        graphicManager.DrawPauseMenu(menuOption);
                        break;

                    case GameState.Continue:
                        try
                        {
                            LoadMap("continue.json");
                            State = GameState.Level;
                            ConnectLevel();
                        }
                        catch (Exception)
                        {
                            State = GameState.NoSave;
                        }
                        break;

                    case GameState.NoSave:
                        graphicManager.DrawNoSaveInfo();
                        break;

                    case GameState.CompleteTutorial:
                        graphicManager.DrawCompleteTutorial();
                        break;

                    case GameState.LoadTutorial:
                        if( tutorialInfo.CurrentLevel > tutorialInfo.TotalLevels)
                        {
                            State = GameState.CompleteTutorial;
                            ConnectMenu();
                            menuOption = 0;
                        }
                        else
                        {
                            LoadMap("levels/tutorial" + tutorialInfo.CurrentLevel + ".json");
                            State = GameState.Tutorial;
                        }
                        break;

                    case GameState.LoadLevel:
                        if (playerInfo.CurrentLevel > playerInfo.TotalLevels)
                        {
                            State = GameState.Progress;
                            ConnectMenu();
                            menuOption = 1;
                        }
                        else
                        {
                            LoadMap("levels/level" + playerInfo.CurrentLevel + ".json");
                            State = GameState.Level;
                        }
                        break;

                    case GameState.Level:
                       graphicManager.DrawMap(map);
                       graphicManager.DrawScore(playerInfo.Score, playerInfo.CurrentLevel, cheater);
                        break;

                    case GameState.Tutorial:
                        graphicManager.DrawMap(map);
                        graphicManager.DrawScore(tutorialInfo.Score, tutorialInfo.CurrentLevel, cheater);
                        graphicManager.DrawHint(tutorialInfo.CurrentLevel);
                        break;

                    case GameState.NextLevel:
                        playerInfo.NextLevel();
                        State = GameState.LoadLevel;
                        break;

                    case GameState.NextTutorial:
                        tutorialInfo.NextLevel();
                        State = GameState.LoadTutorial;
                        break;

                    case GameState.Restart:
                        RestoreMap();
                        playerInfo.ResetLevel();
                        State = GameState.Level;
                        cheater = false;
                        break;

                    case GameState.RestartTutorial:
                        RestoreMap();
                        tutorialInfo.ResetLevel();
                        State = GameState.Tutorial;
                        cheater = false;
                        break;


                    case GameState.Exit:
                        window.Close();
                        break;
                }
                window.Display();
            }
            SavePlayerInfo();
           // if(map is not null)
           //     SaveMap("continue.json");
        }

        private void OnKeyPressedMenu(object sender, KeyEventArgs e)
        {
            int max=0;
            switch(State)
            {
                case GameState.MainMenu:
                    max = (int)MaxOption.MainMenu;
                    break;
                case GameState.Complete:
                    max = (int)MaxOption.Complete;
                    break;
                case GameState.About:
                    max = (int)MaxOption.About;
                    break;
                case GameState.NoSave:
                    max = (int)MaxOption.NoSave;
                    break;
                case GameState.Progress:
                    max = (int)MaxOption.Progress;
                    break;
                case GameState.HardReset:
                    max = (int)MaxOption.HardReset;
                    break;
                case GameState.Pause:
                    max = (int)MaxOption.Pause;
                    break;
            }


            if (keyClock.ElapsedTime >= Time.FromMilliseconds(100))
            {
                secretCodes.Add(e.Code);
                switch (e.Code)
                {
                    case Keyboard.Key.Up:
                    case Keyboard.Key.W:
                        menuOption = (menuOption > 0 ? menuOption-1 : 0);
                        break;
                    case Keyboard.Key.Down:
                    case Keyboard.Key.S:
                        menuOption = (menuOption < max ? menuOption+1 : max);
                        break;
                    case Keyboard.Key.Enter:
                        switch(State)
                        {
                            case GameState.MainMenu:
                                OnConfirmMainMenu();
                                break;
                            case GameState.Complete:
                            case GameState.About:
                            case GameState.NoSave:
                            case GameState.Demo:
                            case GameState.CompleteTutorial:
                                State = GameState.MainMenu;
                                tutorialInfo = new PlayerInfo(true);
                                break;
                            case GameState.Progress:
                                OnConfirmProgress();
                                break;
                            case GameState.Pause:
                                OnConfirmPause();
                                break;
                            case GameState.HardReset:
                                OnConfirmHardReset();
                                break;
                        }
                        break;
                    case Keyboard.Key.Escape:
                        if(State == GameState.Demo)
                        {
                            State = GameState.MainMenu;
                        }
                        break;

                    // secret section 
                    case Keyboard.Key.Num2:
                        if (secretClock.ElapsedTime > Time.FromSeconds(1))
                        {
                            secretClock.Restart();
                            secretCodes.Clear();
                            secretCodes.Add(Keyboard.Key.Num2);
                        }
                        break;
                    case Keyboard.Key.Num6:
                        if (secretClock.ElapsedTime <= Time.FromSeconds(5))
                        {
                            CheckSecretLevel(new List<Keyboard.Key>(secretCodes.TakeLast(3)));
                        }
                        break;
                }
                keyClock.Restart();
            }
        }

        private void OnKeyPressedLevel(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            VectorObject vector = new VectorObject(0, 0);
            int moves;

            

            if (keyClock.ElapsedTime >= Time.FromMilliseconds(70))
            {
                secretCodes.Add(e.Code);
                switch (e.Code)
                {
                    case Keyboard.Key.Escape:
                        if (State == GameState.Tutorial)
                            State = GameState.MainMenu;
                        else
                            State = GameState.Pause;
                        menuOption = 0;
                        ConnectMenu();
                        break;

                    case Keyboard.Key.Up:
                        


                        // stuff for secrets
                        if(secretClock.ElapsedTime > Time.FromSeconds(3))
                        {
                            secretClock.Restart();
                            secretCodes.Clear();
                            secretCodes.Add(Keyboard.Key.Up);
                        }
                        

                        // move stuff
                        vector.X = 0;
                        vector.Y = 1;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            if (State == GameState.Tutorial)
                                tutorialInfo.AddMove(moves);
                            else
                                playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                if (State == GameState.Tutorial)
                                    State = GameState.NextTutorial;
                                else
                                State = GameState.NextLevel;
                            }
                        }

                        prototype.SpriteId = (int)PlayerTexture.playerUp;

                        break;
                    case Keyboard.Key.Down:

                        // move stuff
                        vector.X = 0;
                        vector.Y = -1;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            if (State == GameState.Tutorial)
                                tutorialInfo.AddMove(moves);
                            else
                                playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                if (State == GameState.Tutorial)
                                    State = GameState.NextTutorial;
                                else
                                    State = GameState.NextLevel;
                            }
                        }

                        prototype.SpriteId = (int)PlayerTexture.playerDown;

                        break;
                    case Keyboard.Key.Left:
                        // move stuff
                        vector.X = -1;
                        vector.Y = 0;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            if (State == GameState.Tutorial)
                                tutorialInfo.AddMove(moves);
                            else
                                playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                if (State == GameState.Tutorial)
                                    State = GameState.NextTutorial;
                                else
                                    State = GameState.NextLevel;
                            }
                        }

                        prototype.SpriteId = (int)PlayerTexture.playerLeft;

                        break;
                    case Keyboard.Key.Right:

                        // move stuff
                        vector.X = 1;
                        vector.Y = 0;
                        moves = map.Update(vector);
                        if (moves > 0)
                        {
                            if (State == GameState.Tutorial)
                                tutorialInfo.AddMove(moves);
                            else
                                playerInfo.AddMove(moves);
                            if (map.IsWon())
                            {
                                if (State == GameState.Tutorial)
                                    State = GameState.NextTutorial;
                                else
                                    State = GameState.NextLevel;
                            }
                        }

                        prototype.SpriteId = (int)PlayerTexture.playerRight;

                        break;

                    case Keyboard.Key.R:
                        secretCodes.Clear();
                        secretClock.Restart();
                        if (State == GameState.Tutorial)
                            State = GameState.RestartTutorial;
                        else
                            State = GameState.Restart;
                        break;


                    case Keyboard.Key.A:
                        if(secretClock.ElapsedTime <= Time.FromSeconds(6))
                        {
                            CheckKonami(new List<Keyboard.Key>(secretCodes.TakeLast(10)));
                        }
                        break;

                }

                keyClock.Restart();
            }

               
        }

        private void OnConfirmMainMenu()
        {


            switch (menuOption)
            {
                case 0: // play
                    playerInfo.ResetLevel();
                    State = GameState.LoadLevel;
                    ConnectLevel();
                    break;
                case 1: // continue
                    State = GameState.Continue;
                    menuOption = 0;
                    break;
                case 2: // tutorial 
                    State = GameState.LoadTutorial;
                    ConnectLevel();
                    break;
                case 3: // about
                    State = GameState.About;
                    menuOption = 0;
                    break;
                case 4: // progress
                    State = GameState.Progress;
                    menuOption = 1;
                    break;
                case 5: // exit
                    window.Close();
                    break;
            }
        }

        private void OnConfirmProgress()
        {
            switch (menuOption)
            {
                case 0: //reset
                    State = GameState.HardReset;
                    menuOption = 1;
                    break;
                case 1:
                    State = GameState.MainMenu;
                    menuOption = 0;
                    break;
            }
        }

        private void OnConfirmHardReset()
        {
            switch (menuOption)
            {
                case 0: // yes
                    playerInfo.HardReset();
                    SavePlayerInfo();
                    State = GameState.Complete;
                    menuOption = 0;
                    break;
                case 1:
                    State = GameState.MainMenu;
                    menuOption = 0;
                    break;
            }
        }

        private void OnConfirmPause()
        {
            switch (menuOption)
            {
                case 0: // resume
                    State = GameState.Level;
                    ConnectLevel();
                    break;
                case 1: // restart
                    State = GameState.Restart;
                    ConnectLevel();
                    break;
                case 2: // save and exit
                    SaveMap("continue.json");
                    SavePlayerInfo();
                    State = GameState.Complete;
                    menuOption = 0;
                    break;
                case 3: // exit
                    State = GameState.MainMenu;
                    RestoreMap();
                    LoadPlayerInfo();
                    menuOption = 0;
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

            Box box = new Box();
            Random rnd = new Random();
            if(rnd.Next(0, 2) == 1)
            {
                box.SpriteId = 18; // secret texture
            }
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
            tutorialInfo = new PlayerInfo(true);
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
                Wall hack = new Wall();
                hack.IsWall = false;
                cheater = true;
            }
        }

        private void CheckSecretLevel(List<Keyboard.Key> secretCodes)
        {
            if(secretCodes[0] == Keyboard.Key.Num2 && secretCodes[1] == Keyboard.Key.Num5 && secretCodes[2] == Keyboard.Key.Num6)
            {
                menuOption = 0;
                State = GameState.Demo;
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
