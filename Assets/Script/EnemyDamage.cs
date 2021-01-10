using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collison)
	{
		if (collison.tag == "Bullet") 
		{
			if (gameObject.tag == "Enemy 1")
			{	
				Destroy (gameObject);
				FindObjectOfType<PlayerMovement> ().totalscore += 10;
			}
			else if (transform.parent.gameObject.tag == "Enemy 2")
			{
				
				Destroy (transform.parent.gameObject);
				FindObjectOfType<PlayerMovement> ().totalscore += 15;

			}
		}
		if (collison.tag == "Vitamin") 
		{
			Destroy (transform.parent.gameObject);
		}
	}
}

