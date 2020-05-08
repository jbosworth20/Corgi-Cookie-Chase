using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadHouse : MonoBehaviour {

	//public NavMeshSurface surface;

	// Use this for initialization
	void Start () {
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		List<GameObject> rooms = GameObject.FindGameObjectsWithTag("Room").ToList();
		System.Random rnd = new System.Random();

		foreach (GameObject point in spawnPoints) {
			int i = rnd.Next(0, rooms.Count()-1);
			Instantiate(rooms[i], point.transform.position, point.transform.rotation);
			rooms.RemoveAt(i);
		}
	}
}
