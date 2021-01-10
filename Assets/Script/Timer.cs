using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float leveltime;
	public GameObject spawn;
	public Transform player;
	float delaytime;


	public Text timer;
	// Use this for initialization
	void Start () {
		leveltime = 300f;
		delaytime = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) 
		{
			GameObject go = GameObject.FindGameObjectWithTag ("Player");

			if (go != null) 
			{
				player = go.transform;
			}
		}

		if (delaytime > 0) 
		{
			delaytime -= Time.deltaTime;
		}

		leveltime -= Time.fixedDeltaTime;


		timer.text = Mathf.Round(leveltime).ToString ();

		if (leveltime < 0) 
		{
			FindObjectOfType<GameOver> ().isDead = true;
		}	



		if (SceneManager.GetActiveScene().name == "Stage 3" || SceneManager.GetActiveScene().name == "Stage 4")
			{
			if (Mathf.FloorToInt (leveltime % 3) == 0 && delaytime <= 0) {
				delaytime = 1;
				Instantiate (spawn, new Vector3 (player.position.x, 22.94f, 0), transform.rotation);
			} 
		}
	}

}
