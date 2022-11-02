using UnityEngine;

public class SwitchSceneManager : MonoBehaviour
{
    public GameObject mainGame;
    public GameObject mainMenu;

    public void loadMainGame()
    {
        mainMenu.SetActive(false);
        mainGame.SetActive(true);
    }

    public void loadMainMenu()
    {
        mainMenu.SetActive(true);
        mainGame.SetActive(false);
    }

    public void exitApp()
    {
        Application.Quit();
    }
}
