using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour {
	[SerializeField] string characterName = "default";
	[SerializeField] Text characterNameText;

	[SerializeField] float speed = 500f;
	[SerializeField] float rotationSpeed = 10f;
	
	Rigidbody2D rb;
	public bool isFrozen = false;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		characterNameText.text = characterName;
	}

	public void Move(float move){
		if (!isFrozen){
			rb.velocity = transform.up * move * speed * Time.deltaTime;
		}
		
	}

	public void Rotate(float rotation){
		rb.MoveRotation(rb.rotation - rotation * rotationSpeed * Time.deltaTime);
	}

	//TODO AI is not freezing
	public void Freeze(float freezeTime){
		StartCoroutine(FreezeForATime(freezeTime));
	}

	public IEnumerator FreezeForATime(float freezeTime){
		isFrozen = true;
		yield return new WaitForSeconds(freezeTime);
		isFrozen = false;
	}
	
}
