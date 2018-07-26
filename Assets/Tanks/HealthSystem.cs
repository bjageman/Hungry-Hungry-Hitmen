﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {
	[SerializeField] int maxHealthPoints = 100;
	[SerializeField] Text currentHealthPointsText;

	int currentHealthPoints;

	// Use this for initialization
	void Start () {
		currentHealthPoints = maxHealthPoints;
		currentHealthPointsText.text = currentHealthPoints.ToString();
	}
	
	public void ChangeHealth(int amount){
		currentHealthPoints += amount;
		currentHealthPointsText.text = currentHealthPoints.ToString();
		//TODO Blink for damage
		if (currentHealthPoints <= 0){
			Die();
		}
	}

    private void Die()
    {
        //Make Sound
		//Create Explosion
		Destroy(gameObject, 0.1f);
		//Respawn
    }

}
