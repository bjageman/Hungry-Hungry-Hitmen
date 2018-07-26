using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet {
	[SerializeField] float freezeTime = 3f;

	TankController tankController;

	protected override void SpecialAttack(Collider2D collider){
		print("freeze " + collider.gameObject.name);
		tankController = collider.GetComponent<TankController>();
		tankController.Freeze(freezeTime);
	}

	//TODO Gets destroyed before it can finish
	
}
