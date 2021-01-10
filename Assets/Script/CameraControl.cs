using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform playerPosition;
	public Vector3 offset;
	public float smoothtransition;
	public Vector3 min, max;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		camerafollow ();
	}

	void camerafollow()
	{
		Vector3 playerCamera = playerPosition.position + offset;

		Vector3 limits = new Vector3
			(
				Mathf.Clamp(playerCamera.x,min.x,max.x),
				Mathf.Clamp(playerCamera.y,min.y,max.y),
				Mathf.Clamp(playerCamera.z,min.z,max.z)
			);

		Vector3 playerLocation = Vector3.Lerp (transform.position, limits, smoothtransition * Time.fixedDeltaTime);

		transform.position = playerLocation;
	}

}
