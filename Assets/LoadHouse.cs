using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class LoadHouse : MonoBehaviour {

	public GameObject cookie;

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

		cookie.SetActive(true);

		//--generate navmesh--
		GetComponent<NavMeshSurface>().BuildNavMesh();
	}
}
