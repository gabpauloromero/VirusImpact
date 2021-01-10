using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour {

	public Transform player;
	int speed = 1;
	Rigidbody2D rb2d;

	bool onrange;
	// Use this for initialization
	void Start () {
		onrange = false;
		rb2d = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player == null) 
		{
			GameObject go = GameObject.FindGameObjectWithTag ("Player");

			if (go != null) 
			{
				player = go.transform;
			}
		}

		if (player.position.x>transform.position.x)
		{
			transform.parent.localScale= new Vector3(1,1,1);
		}
		else
		{
			transform.parent.localScale = new Vector3(-1,1,1);
		}	

		if (onrange == true) 
		{
			if (PlayerPrefs.GetString ("Stop") == "no") 
			{	
				transform.parent.position = Vector2.MoveTowards (transform.parent.position, player.position, speed * Time.fixedDeltaTime);
			}
			if (GetComponentInChildren<CollisionCheck> ().collide == true) 
			{	
				rb2d.AddForce (Vector2.up * 30f);
			}
		}
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
			onrange = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		onrange = false;
	}


}
