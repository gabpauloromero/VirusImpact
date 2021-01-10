using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour {
	SpriteRenderer spriteRend;
	// Use this for initialization
	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<Ending>().transform.position == FindObjectOfType<Ending>().location.position)
			{
				spriteRend.enabled = true;
			}
	}
}
