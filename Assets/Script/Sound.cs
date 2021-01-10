using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
	AudioSource bgm;
	// Use this for initialization
	void Start () {
		bgm = GetComponent<AudioSource> ();
		bgm.volume = PlayerPrefs.GetFloat ("Volume");
	}
	
	// Update is called once per frame
	void Update () {
		bgm.volume = PlayerPrefs.GetFloat ("Volume");
	}
}
