using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuToggle : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MapMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }          
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MapMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
       
    }
    void Pause()
    {
        MapMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MapToMenu();
        }
    } 

    void MapToMenu()
    {
        Debug.Log("Estoy en la función MapToMenu");
        MapMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
