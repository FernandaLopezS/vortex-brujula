using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegacyPauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject MapMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                // If in Pause Menu, go back to gameplay.
                if (PauseMenuUI.activeSelf)
                {
                    Resume(PauseMenuUI);
                }
                // If in Map Menu, switch to pause menu.
                if (MapMenuUI.activeSelf)
                {
                    SwitchMenu(MapMenuUI, PauseMenuUI);
                }
            }
            // During gameplay, the pause menu is shown.
            else
            {
                Pause(PauseMenuUI);
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gameIsPaused)
            {
                // If in Pause Menu, go back to gameplay.
                if (PauseMenuUI.activeSelf)
                {
                    SwitchMenu(PauseMenuUI, MapMenuUI);
                }
                // If in Map Menu, switch to pause menu.
                if (MapMenuUI.activeSelf)
                {
                    Resume(MapMenuUI);
                }
            }
            // During gameplay, the pause menu is shown.
            else
            {
                Pause(MapMenuUI);
            }
        }
    }

    public void Resume(GameObject menu)
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    void SwitchMenu(GameObject menu1, GameObject menu2)
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ShowOptions()
    {
        Debug.Log("Showing options...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
