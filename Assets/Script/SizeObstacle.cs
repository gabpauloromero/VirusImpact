using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeObstacle : MonoBehaviour {

	string enemytag;
	public float yaxis;
	public float delaytime;
	Vector2 scaledposition;
	// Use this for initialization
	void Start () 
	{
		scaledposition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (delaytime > 0) {
			delaytime -= Time.deltaTime;
			if (delaytime <= 0) {	
				transform.localScale = new Vector2 (-1f, 1f);
				this.transform.position = scaledposition;
			} 
		}
	}

	void OnTriggerEnter2D(Collider2D collison)
	{
		if (collison.tag == "Bullet") 
		{
			delaytime = 2f;
			transform.localScale = new Vector2 (-2f, 2f);
			this.transform.position = new Vector2 (transform.position.x, yaxis);

		}
	}
}
