using LevelManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : Menu<InGameMenu>
{

    public void OnPausePressed()
    {
        if (MenuManager.Instance && PauseMenu.Instance)
        {
            MenuManager.Instance.OpenMenu(PauseMenu.Instance);
            Time.timeScale = 0;

        }
    }

    public void OnPlayPressed()
    {
        if (MenuManager.Instance && InGameMenu.Instance)
        {
            MenuManager.Instance.OpenMenu(InGameMenu.Instance);
        }
    }

    public void OnSettingsPressed()
    {
        MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
    }



}
