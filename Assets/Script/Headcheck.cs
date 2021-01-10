using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headcheck : MonoBehaviour {

	public bool crouchstat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ground")
			crouchstat = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Ground")
			crouchstat = false;
	}
}
