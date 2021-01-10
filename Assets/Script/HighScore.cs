using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text highscore;
	public Text highscorename;
	public Text besttime;
	public Text besttimename;
	// Use this for initialization
	void Start () 
	{
		highscore.text = PlayerPrefs.GetInt ("Highscore").ToString();
		besttime.text = PlayerPrefs.GetInt ("BestTime").ToString();
		highscorename.text =PlayerPrefs.GetString ("BestScorename");
		besttimename.text = PlayerPrefs.GetString ("BestTimename");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
