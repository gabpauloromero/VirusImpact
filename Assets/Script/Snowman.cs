using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour {

	public GameObject spawn;
	Vector2 startposition;
	// Use this for initialization
	void Start () {
		startposition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet" || other.tag == "Enemy" || other.tag == "Enemy 1" || other.tag == "Enemy 2" || other.tag == "Enemy 3")
		{
			Destroy (gameObject);
			Instantiate (spawn, startposition, transform.rotation);
		}
	}
}
