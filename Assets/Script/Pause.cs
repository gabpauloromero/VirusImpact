using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public bool isPaused = false;
	public GameObject pauseMenu;

	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (isPaused) 
			{
				Resume ();
			}
			else
			{
				Paused();
			}
		}
	}

	public void Resume ()
	{
		isPaused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		PlayerPrefs.SetString ("Stop", "no");
	}

	void Paused ()
	{
		isPaused = true;
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		PlayerPrefs.SetString ("Stop", "yes");
	}

	public void Menu ()
	{
		PlayerPrefs.SetString ("Stop", "no");
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu") ;

	}

	public void Quit ()
	{
		Application.Quit();
	}
}
