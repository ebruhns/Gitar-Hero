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

	public void PlayAllYouNeed()
	{
		SceneManager.LoadScene("AllYouNeed");
	}

	public void PlayhotelCali()
	{
		SceneManager.LoadScene("hotelCali");
	}

	public void PlayStairway()
	{
		SceneManager.LoadScene("stairway2Heaven");
	}

	public void PlayWeWillRockYou()
	{
		SceneManager.LoadScene("WeWillRockYou");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
