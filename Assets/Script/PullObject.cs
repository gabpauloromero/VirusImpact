using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour {

	Vector3 pullDirection;
	public float pullSpeed;
	GameObject box;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.localScale.x == 1f) 
		{	
			pullDirection.x = -1f;
		}
		else if (transform.localScale.x == -1f) 
		{	
			pullDirection.x = 1f;

		}
		if (box !=null && Input.GetKey(KeyCode.LeftControl))
		{
			box.transform.Translate (Time.deltaTime * pullSpeed * pullDirection, Space.World);
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Box")
			box = other.gameObject;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		box = null;
	}

}





