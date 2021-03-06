﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
 	
	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameIsPaused){
				Resume();
			}else{
				Pause();
			}
		}
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
    }

	private void Pause()
    {
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
    } 

	public void MainMenu()
    {
        ResetAll();
        SceneManager.LoadScene(0);
    }

    private static void ResetAll()
    {
        Time.timeScale = 1f;
		TankController[] tanks = FindObjectsOfType<TankController>();
		foreach(TankController tank in tanks){
			Destroy(tank.gameObject);
		}
    }

    

	public void Quit(){
		Application.Quit();
		Debug.Log("quit");
	}
}
