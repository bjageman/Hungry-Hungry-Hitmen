using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour {
	[SerializeField] string characterName = "default";
	[SerializeField] int playerNumber = 1;

	[SerializeField] float speed = 500f;
	[SerializeField] float rotationSpeed = 10f;
	
	Rigidbody2D rb;
	StatusEffects status;

	private static bool created = false;

	public string TankName { 
		get { return characterName;}
		set { characterName = value;}
	}

	public int PlayerNumber {
		get { return playerNumber; }
		set { playerNumber = value; }
	}

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		status = GetComponent<StatusEffects>();
		GetComponent<TankUI>().TankName.text = characterName;
	}

	public void Move(float move){
		if (!status.isFrozen){
			rb.velocity = transform.up * move * speed * Time.fixedDeltaTime;
		}else{
			rb.velocity = Vector3.zero;
		}
		
	}

	public void Rotate(float rotation){
		rb.MoveRotation(rb.rotation - rotation * rotationSpeed * Time.fixedDeltaTime);
	}
	
}
