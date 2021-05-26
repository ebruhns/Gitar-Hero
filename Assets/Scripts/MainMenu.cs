using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
	public void PlaySleepWalk()
	{
		SceneManager.LoadScene("SleepWalk");
	}

	public void PlayDayNNite()
	{
		SceneManager.LoadScene("DayNNite");
	}

	public void PlayYDB()
	{
		SceneManager.LoadScene("YDB");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
