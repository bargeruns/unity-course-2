using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Level Manager Instance
    public LevelManager levelManager;

    // Game state
    enum Screen { MainMenu, Password, Win };

    Screen currentScreen = Screen.MainMenu;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("Hello, human user.");
        ResetPasswords();
    }

    void ResetPasswords()
    {
        levelManager.gameLevels.ForEach(level => level.SetSelectedPassword());
    }

    public void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack today?");
        levelManager.ShowAllLevels();
        ResetPasswords();
    }

    public void StartLevel()
    {
        currentScreen = Screen.Password;
        levelManager.ShowCurrentLevel();
        Terminal.WriteLine("Enter password: ");
        Terminal.WriteLine("Hint: " + levelManager.currentLevel.selectedPassword.Anagram());
        Terminal.WriteLine("(enter 'menu' to exit)");
    }

    void OnUserInput(string input)
    {
        switch (currentScreen)
        {
            case Screen.MainMenu:
                ControlMainMenu(input);
                return;
            case Screen.Password:
                TryPassword(input);
                return;
            case Screen.Win:
                ExitOrReset(input);
                return;
            default:
                ShowMainMenu("Sorry, I didn't understand that. Returning to the main menu now.");
                return;
        }
    }

    private void TryPassword(string input)
    {
        if (levelManager.currentLevel.CheckPassword(passwordAttempt: input))
        {
            Terminal.WriteLine(levelManager.currentLevel.levelWinMessage);
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect password. Try again.");
        }
    }

    private void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("What would you like to do now?");
        Terminal.WriteLine("(exit) -- (menu)");
    }

    private void ExitOrReset(string input)
    {
        if (input == "exit")
            print("exiting game...");
        else
            ShowMainMenu("Returning to main menu.");
    }

    private void ControlMainMenu(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Welcome back, human.");
        } 
        else if (input == "exit")
        {
            Terminal.WriteLine("Goodbye.");
            print("exiting game...");
        } 
        else
        {
            int number;
            var inputToInt = int.TryParse(input, out number);
            if (inputToInt)
            {
                if (levelManager.SetCurrentLevel(number))
                {
                    StartLevel();
                }
                else
                {
                    levelManager.ShowAllLevels();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
