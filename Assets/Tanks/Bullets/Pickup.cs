using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	[SerializeField] float rotateSpeed = 100f;
	[SerializeField] Bullet bulletPickup;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}

	void OnCollisionEnter2D(Collision2D col){
		CombatSystem combatSystem = col.gameObject.GetComponent<CombatSystem>();
		if (combatSystem == null){ return; }
		bool success = combatSystem.LoadBullet(bulletPickup);
		if(success){
			Destroy(gameObject, 0.1f);
		}
	}
}
