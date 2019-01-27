using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public bool gamePaused = false;
	public GameObject pauseMenu;
    public GameObject youWin;

    private void Start()
    {
        Time.timeScale = 1;
    }
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
        Slime.SlimesToDie = 0;
        SceneManager.LoadScene("SceneWithFurniture");
    }

    public void BackToMenu() {
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    public void YouWin() {
        Time.timeScale = 0;
        //Cursor.visible = true;
        youWin.SetActive(true);
    }
}
