using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public float firedelay = 0.25f;
	float cooldown = 0;
	public GameObject bulletprefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.fixedDeltaTime;
		Quaternion rot;
		if (PlayerPrefs.GetString ("Stop") == "no")
		{
			if (Input.GetMouseButton (0) && cooldown <= 0 && FindObjectOfType<PlayerMovement> ().bullettotal > 0) 
			{
				cooldown = firedelay;
				if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {	
					Instantiate (bulletprefab, transform.position, transform.rotation);
				} else if (transform.localScale.x < 0) {
					rot = Quaternion.Euler (0, 0, 90);
					Instantiate (bulletprefab, transform.position, rot);
				} else if (transform.localScale.x > 0) {
					rot = Quaternion.Euler (0, 0, -90);
					Instantiate (bulletprefab, transform.position, rot);
				}
				FindObjectOfType<PlayerMovement> ().bullettotal -= 1;
			}
		}
	}

}
