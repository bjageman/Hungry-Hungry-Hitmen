using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : Bullet {

	protected override void SpecialAttack(Collider2D collider){
		print("do nothing");
	}
}
