using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	TankController tankController;
	CombatSystem combatSystem;

	// Use this for initialization
	void Start () {
		tankController = GetComponent<TankController>();
		combatSystem = GetComponent<CombatSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward();
		Rotate();
		Shoot();
	}

    private void Shoot()
    {
        if (Input.GetButton("Fire1")){
			combatSystem.Shoot();
		}
    }

    private void Rotate()
    {
        float rotation = Input.GetAxisRaw("Horizontal");
		tankController.Rotate(rotation);
    }

    private void MoveForward()
    {
        float forwardMovement = Input.GetAxisRaw("Vertical");
		tankController.Move(forwardMovement);
    }
}
