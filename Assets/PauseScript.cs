using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject pausePanel; 

	// Use this for initialization
	void Start () {
		pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(pausePanel.activeInHierarchy){
				Continue();
			}
			else{
				Pause();
			}
		}
	}
	private void Continue(){
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
	private void Pause(){
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}
}
