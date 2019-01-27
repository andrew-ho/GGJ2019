using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Player : MonoBehaviour {

	public AudioClip otherClip;
    AudioSource audioSource;

    public AudioClip thirdClip;
    bool fightingBoss = false;

    public GameObject pauseManager;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!fightingBoss && !audioSource.isPlaying && !pauseManager.GetComponent<PauseGame>().gamePaused) {
            audioSource.clip = otherClip;
            audioSource.Play();
            audioSource.loop = true;
        }
	}

	public void StartBossMusic() {
		if (!fightingBoss) {
			fightingBoss = true;
			audioSource.clip = thirdClip;
	        audioSource.Play();
	        audioSource.loop = true;
		}
	}

	public void PauseMusic() {
		audioSource.Pause();
	}

	public void ResumeMusic() {
		audioSource.Play();
	}
}
