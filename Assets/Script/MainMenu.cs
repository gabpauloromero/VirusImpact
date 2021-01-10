using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Slider volume;
	public Toggle mutetoggle;

	void Start () {
		volume.value = PlayerPrefs.GetFloat ("Volume");
		if (PlayerPrefs.GetFloat ("Volume") > 0) {
			mutetoggle.isOn = false;
		}

	}

	public void Play()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		PlayerPrefs.SetInt ("Totalbullet", 0);
		PlayerPrefs.SetInt ("Score", 0);

	}

	public void Quit ()
	{
		Application.Quit();
	}
}
