using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void changeScene(string scene){
		System.String name = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(scene);
		SceneManager.UnloadSceneAsync(name);
		
	}
}
