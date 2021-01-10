using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitamins : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 45) * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "invul") 
		{
			Destroy (gameObject);
			FindObjectOfType<PlayerMovement> ().totalscore += 5;
		}
		if (other.tag == "Enemy" || other.tag == "Enemy 1" || other.tag == "Enemy 2" || other.tag == "Enemy 3")
			Destroy (other.gameObject);
	}
}
