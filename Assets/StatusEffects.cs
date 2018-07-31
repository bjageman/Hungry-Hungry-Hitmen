using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour {

	public bool isFrozen = false;

	public void Freeze(float freezeTime){
		StartCoroutine(FreezeForATime(freezeTime));
	}

	public IEnumerator FreezeForATime(float freezeTime){
		isFrozen = true;
		GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(freezeTime);
		GetComponent<SpriteRenderer>().color = Color.white;
		isFrozen = false;
	}
}
