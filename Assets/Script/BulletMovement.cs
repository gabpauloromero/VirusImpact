using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {


	float bulletspeed = 5f;
	float timer = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.fixedDeltaTime;
		if (timer<=0)
		{
			Destroy(gameObject);
		}
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, bulletspeed * Time.fixedDeltaTime, 0);

		pos += transform.rotation * velocity;
		transform.position = pos;


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Ground") 
		{
			Destroy (gameObject);
		}
		if (other.tag == "Enemy" || other.tag == "Enemy 1" || other.tag == "Enemy 2" || other.tag == "Enemy 3" || other.tag == "Cactus") 
		{
			Destroy (gameObject);
		}
		if (other.tag == "Box") 
		{
			Destroy (gameObject);
		}
		if (other.tag == "snowman") 
		{
			Destroy (gameObject);
		}
	}
}
