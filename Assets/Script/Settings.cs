using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Slider settingvolume;
	public Toggle mutetoggle;

	public void SetVolume (float volume)
	{
		PlayerPrefs.SetFloat ("Volume", volume);
		if (PlayerPrefs.GetFloat ("Volume") == 0f) {
			mutetoggle.isOn = true;
		} else {
			mutetoggle.isOn = false;
		}
	}

	public void Mute (bool mute)
	{
		if (mute == true) {
			PlayerPrefs.SetFloat ("Volume", 0);
			settingvolume.value = PlayerPrefs.GetFloat ("Volume");
		} else 
		{
			PlayerPrefs.SetFloat ("Volume", 0.1f);
			settingvolume.value = PlayerPrefs.GetFloat ("Volume");
		}
	}

	public void setresolution (int resolutionindex)
	{
		if (resolutionindex == 0) 
		{
			Screen.SetResolution (1280, 720, Screen.fullScreen);
		}
		else if (resolutionindex == 1) 
		{
			Screen.SetResolution (1024, 576, true);
		}
		else if (resolutionindex == 2) 
		{
			Screen.SetResolution (720, 480, true);
		}
	}
}
