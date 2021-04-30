using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsComplete = false;
    public GameObject pauseMenuUI;
    public GameObject gameCompleteMenuUI;
    

    void Start()
    {
        pauseMenuUI.SetActive(false);
        gameCompleteMenuUI.SetActive(false);
        GameIsPaused = false;
        GameIsComplete = false;
    }
    void Update()
    {   
        //if game is complete show game complete menu.
        if(GameIsComplete)
        {  
            GameCompletePause();
        } 
        //if the game is over and the game is not complete, you can press esc to open the pause menu and esc again to unpause.
        else
        {     
            // if the player hit esc
            if(Input.GetKeyDown(KeyCode.Escape))
            {   
                // if the game is paused and esc is pressed, continue .
                if(GameIsPaused)
                {
                    Resume();
                } 
                // else pause the game.
                else 
                {
                    Pause();
                }
            }
        }
    }

// while the game is playing this will be the state, it will have the pause menu hidden.
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

// while the game is paused it displays the pause menu
    void Pause()
    {    
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }
    //shows the game complete menu
    public void GameCompletePause()
    {
        gameCompleteMenuUI.SetActive(true);
        GameIsComplete = true;
    }
    //finds the current scene and loads it.
    public void Restart()
    {   
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
