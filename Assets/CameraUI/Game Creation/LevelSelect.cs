using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	[SerializeField] Text levelName;
	[SerializeField] Sprite[] levelImages;
	[SerializeField] Image displayedLevelImage;

	//0=main menu, 1=level create
	int currentLevelIndex = 0;
	int startingLevelIndex = 2;

	public void NextLevel(){
		currentLevelIndex = (currentLevelIndex + 1) % levelImages.Length;
		print(levelImages.Length);
		print(currentLevelIndex);
		Sprite levelImage = levelImages[currentLevelIndex];
		displayedLevelImage.sprite = levelImage;
		print(levelImage.name);
		levelName.text = levelImage.name;
	}

	public void LoadLevel(){
		foreach (TankController player in Resources.FindObjectsOfTypeAll<TankController>()){
			player.gameObject.SetActive(true);
		}
		SceneManager.LoadScene(currentLevelIndex + startingLevelIndex);
	}
}
