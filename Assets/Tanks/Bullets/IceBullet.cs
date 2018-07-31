using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet {
	[SerializeField] float freezeTime = 3f;

	TankController tank;

	protected override void SpecialAttack(Collider2D collider){
		tank = collider.GetComponent<TankController>();
		tank.GetComponent<StatusEffects>().Freeze(freezeTime);
	}
	
}
