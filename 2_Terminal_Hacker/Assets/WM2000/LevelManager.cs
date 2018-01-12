using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour  {
        public List<Level> gameLevels = new List<Level>();
        public Level currentLevel;

        public void AddNewLevel(Level newLevel)
        {
            gameLevels.Add(newLevel);
        }

        public bool SetCurrentLevel(int number) {
            if (gameLevels.Exists(l => l.levelNumber == number))
            {
                currentLevel = gameLevels.Find(l => l.levelNumber == number);
                return true;
            } else {
                Terminal.WriteLine("Invalid level number. Please select a valid level.");
                return false;
            }
        }

        public void ShowCurrentLevel()
        {
            Terminal.WriteLine(currentLevel.levelNumber + " -- " + currentLevel.levelName);
            Terminal.WriteLine(currentLevel.levelGreeting);
        }

        public void ShowAllLevels()
        {
            gameLevels.ForEach(level => Terminal.WriteLine(level.levelNumber + " -- " + level.levelName));
        }
}
