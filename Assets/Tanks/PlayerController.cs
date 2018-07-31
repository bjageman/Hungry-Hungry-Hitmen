using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	TankController tankController;
	CombatSystem combatSystem;

	Dictionary<string, string> player1Controls = new Dictionary<string, string>()
	{
		{"Fire","P1Fire"},
		{"Horizontal", "P1Horizontal"},
		{"Vertical","P1Vertical"}
	};
	Dictionary<string, string> player2Controls = new Dictionary<string, string>()
	{
		{"Fire","P2Fire"},
		{"Horizontal", "P2Horizontal"},
		{"Vertical","P2Vertical"}
	};
	Dictionary<string, string> controls;

	// Use this for initialization
	void Start () {
		tankController = GetComponent<TankController>();
		combatSystem = GetComponent<CombatSystem>();
		if (tankController.PlayerNumber == 1) { controls = player1Controls;}
		else if (tankController.PlayerNumber == 2) { controls = player2Controls;}
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward();
		Rotate();
		Shoot();
	}

    private void Shoot()
    {
        if (Input.GetButton(controls["Fire"])){
			combatSystem.Shoot();
		}
    }

    private void Rotate()
    {
        float rotation = Input.GetAxisRaw(controls["Horizontal"]);
		tankController.Rotate(rotation);
    }

    private void MoveForward()
    {
        float forwardMovement = Input.GetAxisRaw(controls["Vertical"]);
		tankController.Move(forwardMovement);
    }
}
