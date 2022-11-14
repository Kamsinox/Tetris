using UnityEngine;
using Tomino;

public class SwitchSceneManager : MonoBehaviour
{
    public GameObject mainGame;
    public GameObject mainMenu;
    public Game game;

    public void loadMainGame()
    {
        mainMenu.SetActive(false);
        mainGame.SetActive(true);
        game.Start();
    }

    public void loadMainMenu()
    {
        mainGame.SetActive(false);
        mainMenu.SetActive(true);
        game.Start();
    }

    public void exitApp()
    {
        Application.Quit();
    }
}
