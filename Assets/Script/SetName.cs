using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour {
	private InputField inputField;
	public string name;
	// Use this for initialization
	void Start () {
		inputField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	public void PrintNewValue (){
		name = inputField.text.ToString();
	}
}
