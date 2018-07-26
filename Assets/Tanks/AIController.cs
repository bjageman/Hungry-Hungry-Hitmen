using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	
	[SerializeField] float fireRadius = 5f;
	
	TankController tankController;
	List<TankController> targets;

	TankController currentTarget;
	CombatSystem combatSystem;

	// Use this for initialization
	void Start () {
		tankController = GetComponent<TankController>();
		combatSystem = GetComponent<CombatSystem>();
	}

	// Update is called once per frame
	void Update ()
    {
		GetClosestTarget();
		if (TargetInRadius()){
			tankController.Move(0);
			LookAtTarget();
        	Shoot();
		}else{
			MoveTowardsClosestTarget();
		}
		
    }

    private void MoveTowardsClosestTarget()
    {
        //Foreach through all targets, both players and pickups
		//Move towards a pickup unless maxed out, then move towards player
		LookAtTarget();
		tankController.Move(1);
    }

    private bool TargetInRadius()
    {
		float distance = Vector3.Distance(currentTarget.transform.position, transform.position);
		if (distance < fireRadius){
			return true;
		}
		return false;
    }

	private void GetClosestTarget()
    {
		targets = new List<TankController>(FindObjectsOfType<TankController>());
		targets.Remove(tankController);
		TankController closestTarget = null;
		float closestTargetDistance = 1000f;
        foreach(TankController target in targets){
			float currentDistance = Vector3.Distance(target.transform.position, transform.position);
			if (currentDistance < closestTargetDistance){
				closestTarget = target;
				closestTargetDistance = currentDistance;
			}
		}
		currentTarget = closestTarget;
    }

	//AI will spin wildly before locking on player
    private void LookAtTarget()
    {
        float angle = Vector3.Angle(transform.up, transform.position - currentTarget.transform.position);
		if (angle < 178){
			tankController.Rotate(-1);
		}else{
			tankController.Rotate(1);
		}
    }

    private void Shoot()
    {
        combatSystem.Shoot();
    }

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, fireRadius);

	}
}
