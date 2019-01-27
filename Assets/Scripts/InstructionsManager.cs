using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour {

	public GameObject insMenu;
	public GameObject title;
	public GameObject egg;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
        	CloseInstructions();
        }
    }

    public void OpenInstructions() {
    	insMenu.SetActive(true);
    	title.SetActive(false);
    	egg.SetActive(false);
    	button1.SetActive(false);
    	button2.SetActive(false);
    	button3.SetActive(false);
    	button4.SetActive(true);
    }

    public void CloseInstructions() {
    	insMenu.SetActive(false);
    	title.SetActive(true);
    	//egg.SetActive(true);
    	button1.SetActive(true);
    	button2.SetActive(true);
    	button3.SetActive(true);
    	button4.SetActive(false);
    }
}
