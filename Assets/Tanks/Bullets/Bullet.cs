using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {
	[SerializeField] int damagePerHit = 5;

	protected abstract void SpecialAttack(Collider2D collider);

	public void OnTriggerEnter2D(Collider2D collider){
		HealthSystem healthSystem = collider.GetComponent<HealthSystem>();
		if (healthSystem){
			SpecialAttack(collider);
			healthSystem.ChangeHealth(-damagePerHit);
			Destroy(gameObject, 0.1f);
		}
		
	}
}
