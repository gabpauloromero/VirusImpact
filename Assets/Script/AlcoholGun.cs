using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Enemy 1" || other.tag == "Enemy 2" || other.tag == "Enemy 3") 
		{
			Destroy (gameObject);
		}
	}
}
