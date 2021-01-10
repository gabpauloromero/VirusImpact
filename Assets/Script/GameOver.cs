using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public bool isDead = false;
	public GameObject gameoverMenu;
	public GameObject textfield;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
		{
			Over();
		}
	}

	public void Restart ()
	{
		isDead = false;
		gameoverMenu.SetActive (false);
		SceneManager.LoadScene((SceneManager.GetActiveScene ().buildIndex));
		PlayerPrefs.SetString ("Stop", "no");
		Time.timeScale = 1f;
	}

	void Over ()
	{
		isDead = true;
		PlayerPrefs.SetString ("Stop", "yes");
		gameoverMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	public void Menu ()
	{
		PlayerPrefs.SetString ("Stop", "yes");
		Time.timeScale = 0f;
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Highscore")) 
		{
				FindObjectOfType<PlayerMovement> ().bestscorename = true;
				PlayerPrefs.SetInt ("Highscore", PlayerPrefs.GetInt ("Score"));
				textfield.SetActive (true);
				gameoverMenu.SetActive (false);
				isDead = false;
		} 
		else 
		{
			isDead = false;
			SceneManager.LoadScene ("Menu");
		}
	}

	public void Menu2()
	{	
		PlayerPrefs.SetString ("Stop", "no");
		Time.timeScale = 1f;
		isDead = false;
		if (SceneManager.GetActiveScene ().name == "Stage 4") {
			SceneManager.LoadScene ("Loading 5");
		} 
		else 
		{
			SceneManager.LoadScene ("Menu");
		}

		if (FindObjectOfType<PlayerMovement> ().bestscorename == true) 
		{
			PlayerPrefs.SetString ("BestScorename", FindObjectOfType<SetName> ().name);
		}
		if (FindObjectOfType<PlayerMovement> ().besttimename == true)
		{
			PlayerPrefs.SetString ("BestTimename", FindObjectOfType<SetName> ().name);
		}

	}

	public void Quit ()
	{
		Application.Quit();
	}


}
