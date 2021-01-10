using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

	public Image fill;
	public float health;

	public Image stamfill;
	public float stamina = 10f;

	public void LoseHealth(int value)
	{
		health -= value;
		fill.fillAmount = health / 100;
		if (health == 0) 
		{
			FindObjectOfType<GameOver> ().isDead = true;
		}
	}

	public void LoseStamina(float value)
	{
		stamina -= value;
		stamfill.fillAmount = stamina/ 12;
	}

	public void GainStamina(float value)
	{
		stamina += value;
		stamfill.fillAmount = stamina/ 12;
	}
}
