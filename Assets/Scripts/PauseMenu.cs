using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI; 

    public GameObject optionsMenuUI;

    // Update is called once per frame
  /* public void Onpress_escape(InputAction.CallbackContext context)
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
    

    public void Resume()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	//make countdown happen
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    void Pause()
    {
    	SceneManager.LoadScene("PauseMenu");
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);

    }

    /// <summary>
    /// 
    /// </summary>
    public void QuitGame()
    {
      Application.Quit();
    }*/
}
