using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CookieScript : MonoBehaviour {

    public GameObject cookie;
	public Text text;

	private int cookieCount;
	private System.Random rnd;
	private List<GameObject> cookiePoints;
    public PlayAudio audio;

    // Use this for initialization
    void Start() {
        rnd = new System.Random();
        //--spawn in cookie--
		cookiePoints = GameObject.FindGameObjectsWithTag("CookiePoint").ToList();
		cookieCount = -1;
		spawnCookie();
        audio = FindObjectOfType<PlayAudio>();
    }

    void spawnCookie(){
		if(cookieCount == 4){
			print("Victory!");
            //Sound below is played for a win:
            
            audio.PlayAtLocation(2, transform.position);
        }
		else{
			int j = rnd.Next(0, cookiePoints.Count()-1);
			cookie.transform.position = cookiePoints[j].transform.position;
			cookieCount++;
			cookiePoints.RemoveAt(j);
			if(text)
				text.text = "Score: " + cookieCount + "/5";
		}
	}
	void OnTriggerEnter(Collider c){
        //These two lines below play the noise for getting the cookie
        audio.PlayAtLocation(1, transform.position);
        spawnCookie();
	}
}
