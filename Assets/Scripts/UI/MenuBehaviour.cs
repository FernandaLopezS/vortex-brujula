using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    // References to the pause and map menus
    public GameObject pauseMenuUI;
    public GameObject mapMenuUI;

    // A boolean to keep track of whether the game is paused or not
    public static bool GameIsPaused = false;
    // A boolean to keep track of whether the map menu is opened or not
    public static bool MapIsOpened = false;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is paused, resume it
            if (GameIsPaused)
            {
                Resume();
            }
            // Otherwise, pause it
            else
            {
                Pause();
            }
        }

        // Check if the Tab key is pressed and the game is not paused
        if (Input.GetKeyDown(KeyCode.Tab) && !GameIsPaused)
        {
            // If the map menu is already opened, close it
            if (MapIsOpened)
            {
                CloseMap();
            }
            // Otherwise, open it
            else
            {
                OpenMap();
            }
        }
    }

    // Function to resume the game
    void Resume()
    {
        pauseMenuUI.SetActive(false); // Deactivate the pause menu
        Time.timeScale = 1f; // Set the time scale to normal (unpause time)
        GameIsPaused = false; // Set GameIsPaused to false
    }

    // Function to pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Activate the pause menu
        Time.timeScale = 0f; // Set the time scale to 0 (freeze time)
        GameIsPaused = true; // Set GameIsPaused to true
    }

    // Function to open the map menu
    void OpenMap()
    {
        mapMenuUI.SetActive(true); // Activate the map menu
        MapIsOpened = true; // Set MapIsOpened to true
        Time.timeScale = 0f; // Set the time scale to 0 (freeze time)
    }

    // Function to close the map menu
    void CloseMap()
    {
        mapMenuUI.SetActive(false); // Deactivate the map menu
        MapIsOpened = false; // Set MapIsOpened to false
        Time.timeScale = 1f; // Set the time scale to normal (unpause time)
    }

    // Function to load the main menu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f; // Set the time scale to normal (unpause time)
        SceneManager.LoadScene("Menu"); // Load the "Menu" scene
    }

    // Function to show the options menu
    public void ShowOptions()
    {
        Debug.Log("Showing options..."); // Log a message to the console
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // Log a message to the console
        Application.Quit(); // Quit the application
    }
}
