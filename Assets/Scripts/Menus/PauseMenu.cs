using LevelManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : Menu<PauseMenu>
{

    [SerializeField]
    int mainMenuIndex = 0;
    public void OnResumePressed()
    {
        Time.timeScale = 1;

    }



    public void OnRestartPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuIndex);

        if (MenuManager.Instance && MainMenu.Instance)
        {
            MenuManager.Instance.OpenMenu(MainMenu.Instance);

        }
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
