using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieScript : MonoBehaviour {

    public GameObject cookie;

	private int cookieCount;
	private System.Random rnd;
	private GameObject[] cookiePoints;
    public PlayAudio audio;

    // Use this for initialization
    void Start() {
        rnd = new System.Random();
        //--spawn in cookie--
		cookiePoints = GameObject.FindGameObjectsWithTag("CookiePoint");
		cookieCount = 0;
		spawnCookie();
        audio = FindObjectOfType<PlayAudio>();
    }

    void spawnCookie(){
		if(cookieCount >= 5){
			print("Victory!");
            //Sound below is played for a win:
            
            audio.PlayAtLocation(2, transform.position);
        }
		else{
			int j = rnd.Next(0, cookiePoints.Length-1);
			cookie.transform.position = cookiePoints[j].transform.position;
			cookieCount++;
		}
	}
	void OnTriggerEnter(Collider c){
        //These two lines below play the noise for getting the cookie
        audio.PlayAtLocation(1, transform.position);
        spawnCookie();
	}
}
