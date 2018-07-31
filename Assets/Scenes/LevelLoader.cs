using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	[SerializeField] GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
		LoadTanksOnSpawnPoints();
	}

    private void LoadTanksOnSpawnPoints()
    {
		TankController[] tanks = FindObjectsOfType<TankController>();
		if (spawnPoints.Length >= tanks.Length){
			foreach (TankController tank in tanks){
					tank.transform.position = spawnPoints[tank.PlayerNumber - 1].transform.position;
			}
		}
    }

    // Update is called once per frame
    void Update () {
		
	}
}
