using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class LoadHouse : MonoBehaviour {

	public GameObject cookie;

	private int cookieCount;

	// Use this for initialization
	void Start () {
		//--generate rooms--
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		List<GameObject> preRooms = GameObject.FindGameObjectsWithTag("Room").ToList();
		System.Random rnd = new System.Random();

		foreach (GameObject point in spawnPoints) {
			int i = rnd.Next(0, preRooms.Count()-1);
			Instantiate(preRooms[i], point.transform.position, point.transform.rotation);
			preRooms[i].SetActive(false);
			preRooms.RemoveAt(i);
		}
		foreach (GameObject room in preRooms){
			room.SetActive(false);
		}

		//--spawn in cookie--
		cookieCount = 0;
		GameObject[] cookiePoints = GameObject.FindGameObjectsWithTag("CookiePoint");
		int j = rnd.Next(0, cookiePoints.Length-1);
		Instantiate(cookie, cookiePoints[j].transform.position, cookie.transform.rotation);
		cookieCount++;

		//--generate navmesh--
		GetComponent<NavMeshSurface>().BuildNavMesh();
	}
}
