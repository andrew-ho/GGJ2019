﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public bool gamePaused = false;
	public GameObject pauseMenu;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
        	if (!gamePaused) {
        		Time.timeScale = 0;
        		gamePaused = true;
        		//Cursor.visible = true;
        		pauseMenu.SetActive(true);
        	} else {
        		pauseMenu.SetActive(false);
        		//Cursor.visible = false;
        		gamePaused = false;
        		Time.timeScale = 1;
        	}
        }
    }

    public void UnpauseGame() {
        pauseMenu.SetActive(false);
        //Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void RestartGame() {
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("SceneWithFurniture");
    }

    public void BackToMenu() {
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
