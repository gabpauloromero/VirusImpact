using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	int speed = 1;
	Rigidbody2D rb2d;
	int hp;
	// Use this for initialization
	void Start () 
	{
		hp = 4;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			transform.localScale= new Vector3(1,1,1);
		}
		else
		{
			transform.localScale = new Vector3(-1,1,1);
		}	

		if (PlayerPrefs.GetString ("Stop") == "no") 
		{	
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.fixedDeltaTime);
		}
	}

	private void OnTriggerEnter2D(Collider2D collison)
	{
		if (collison.tag == "Bullet" || collison.tag == "Vitamin") 
		{
			hp -= 1;
			if (hp == 0) 
			{
				Destroy (gameObject);
				FindObjectOfType<PlayerMovement> ().totalscore += 25;
			}	
		}
	}
}
