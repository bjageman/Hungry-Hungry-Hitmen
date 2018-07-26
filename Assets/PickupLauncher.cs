using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLauncher : MonoBehaviour {
	[SerializeField] float launchRate = 1f;
	[SerializeField] float launchSpeed = 10f;
	[SerializeField] float minLaunchDrag = .2f;
	[SerializeField] float maxLaunchDrag = 1f;
	[SerializeField] float maxRotation = 30f;

	[SerializeField] int maxPickupsOnField = 100;
	[SerializeField] Pickup[] pickups;

	float timeSinceLastPickupLaunched = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeSinceLastPickupLaunched > launchRate){
			timeSinceLastPickupLaunched = Time.time;
			if (FindObjectsOfType<Pickup>().Length < maxPickupsOnField) {
				Pickup pickup = GetRandomPickup();
				LaunchPickup(pickup);
			}
		}
	}

    private void LaunchPickup(Pickup pickup)
    {
        Quaternion originalRotation = transform.rotation;
        transform.Rotate(0f, 0f, UnityEngine.Random.Range(0, maxRotation));
        CreateAndLaunchPickup(pickup);
        transform.rotation = originalRotation;
    }

    private void CreateAndLaunchPickup(Pickup pickup)
    {
        GameObject pickupObject = Instantiate(pickup.gameObject, transform.position, Quaternion.identity);
        Rigidbody2D pickupRB = pickupObject.GetComponent<Rigidbody2D>();
        pickupRB.drag = UnityEngine.Random.Range(minLaunchDrag, maxLaunchDrag);
        pickupRB.AddForce(transform.up * launchSpeed);
    }

    private Pickup GetRandomPickup()
    {
        return pickups[UnityEngine.Random.Range(0, pickups.Length)];
    }
}
