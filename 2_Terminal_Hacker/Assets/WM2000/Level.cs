using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level : MonoBehaviour  {

        public int levelNumber;
        public string levelName;
        public string levelGreeting;

        public string levelWinMessage;
        
        public List<string> levelPasswords = new List<string>();

        public Level(int number, string name, string greeting, string password)
        {
            levelNumber = number; 
            levelName = name;
            levelGreeting = greeting;
            levelPasswords.Add(password);
        }

        public bool CheckPassword(string passwordAttempt) {
            return levelPasswords.Contains(passwordAttempt);
        }
}
