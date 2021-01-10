using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {
	public Transform location;
	public float speed;
	public GameObject vaccine;
	float endtime;
	// Use this for initialization
	void Start () {
		speed = 2f;
		endtime = 30f;
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, location.position, speed * Time.fixedDeltaTime);
		endtime -= Time.fixedDeltaTime;

		if (endtime < 25) 
		{
			vaccine.SetActive (true);
		}	
		if (endtime <= 0) 
		{
			SceneManager.LoadScene ("Loading 4");
		}	

		Debug.Log (endtime);
	}


}
