using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

	public bool collide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		collide = true;
		if (other.tag == "Player" || other.tag == "GunBox")
		{
			collide = false;
		}	
	}

	void OnTriggerExit2D(Collider2D other)
	{
			collide = false;
	}
}
