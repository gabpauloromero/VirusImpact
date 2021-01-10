using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LostGround : MonoBehaviour {
	
	Vector2 startposition;
	public float delaytimes;
	SpriteRenderer spriteRend;
	bool destroy;
	// Use this for initialization
	void Start () {
		startposition = this.transform.position;
		delaytimes = 0;
		spriteRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (delaytimes > 0) 
		{
			delaytimes -= Time.deltaTime;
			if (delaytimes <= 0 && destroy == true) 
		 	{
				spriteRend.enabled = false;
				this.gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
				delaytimes = 2f;
				destroy = false;
			} 
		}

		if (destroy == false) 
		{
			if (delaytimes <= 0) 
			{
				spriteRend.enabled = true;
				this.gameObject.GetComponent<PolygonCollider2D> ().enabled = true;
			} 
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		delaytimes = 2f;
		destroy = true;
	}
}
