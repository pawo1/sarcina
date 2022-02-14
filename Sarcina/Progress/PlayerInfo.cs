using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sarcina.Progress
{
    [Serializable]
    class PlayerInfo
    {
        public int TotalLevels { get; private set; }
        public int CurrentLevel { get; private set; }
        public int TotalScore { get; private set; }
        public int Score { get; private set; }

        public PlayerInfo()
        {
            TotalLevels = 3;
            CurrentLevel = 1;
            TotalScore = 0;
            Score = 0;
        }

        [JsonConstructorAttribute]
        public PlayerInfo(int totalLevels, int currentLevel, int totalScore, int score)
        {
            TotalLevels = totalLevels;
            CurrentLevel = currentLevel;
            TotalScore = totalScore;
            Score = score;
        }

        public int NextLevel()
        {
            CurrentLevel++;
            TotalScore += Score;
            Score = 0;
            return CurrentLevel;
        }

        public void ResetLevel()
        {
            Score = 0;
        }

        public void AddMove(int moved)
        {
            Score += moved;
        }
        
        public void HardReset()
        {
            CurrentLevel = 1;
            TotalScore = 0;
            Score = 0;
        }
    }
}
