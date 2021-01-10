using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public Image stamfill;
	public float stamina = 10f;
	public Text load;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GainStamina (Time.fixedDeltaTime);
		if (stamina >= 1) 
		{
			load.color = Color.red;
		}
		if (stamina >= 4) 
		{
			load.color = Color.green;
		}
		if (stamina >= 8) 
		{
			load.color = Color.blue;
		}
		if (stamina >= 10) 
		{
			if (SceneManager.GetActiveScene ().name == "Loading 4") {
				SceneManager.LoadScene ("Menu");
			}
			else if (SceneManager.GetActiveScene ().name == "Loading 5") {
				SceneManager.LoadScene ("Ending");
			}else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
		}

	}

	public void GainStamina(float value)
	{
		stamina += value;
		stamfill.fillAmount = stamina/ 10;
	}
}
