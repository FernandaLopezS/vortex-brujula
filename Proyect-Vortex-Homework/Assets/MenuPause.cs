using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    // The game isnt't pause (traks if it is pause or not)
    public static bool GamePause = false;  //public = accesible from other scripts // static = don't want to reference this specific manuscript, just check status
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause) Resume();
            else Pause();
        }
    }

    public void Resume() //make it public = triger it from a botton
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // movement
        GamePause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //inable
        Time.timeScale = 0f; //no movement (stop time)
        GamePause = true;
    } 

    public void LoadMenu()
    {
        Debug.Log("Loading");
        //Time.timeScale = 1f; //don't stop time in the scene
        //SceneManager.LoadScene("Menu")
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
