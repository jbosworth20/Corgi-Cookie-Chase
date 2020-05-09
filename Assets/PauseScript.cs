using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject canvas; 

	// Use this for initialization
	void Start () {
		canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(canvas.activeInHierarchy){
				Continue();
			}
			else{
				Pause();
			}
		}
	}
	public void Continue(){
		Time.timeScale = 1;
		canvas.SetActive(false);
	}
	public void Pause(){
		Time.timeScale = 0;
		canvas.SetActive(true);
	}
}
