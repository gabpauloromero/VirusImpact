using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject enemyspawn;
	public float spawnx;
	public float spawny;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Instantiate(enemyspawn, new Vector3(spawnx, spawny, 0), transform.rotation);
			Destroy (gameObject);
		}

	}
}
