using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	int levelIndex = 1;

	public void LoadLevel(){
		foreach (TankController player in Resources.FindObjectsOfTypeAll<TankController>()){
			player.gameObject.SetActive(true);
		}
		SceneManager.LoadScene(levelIndex);
	}
}
