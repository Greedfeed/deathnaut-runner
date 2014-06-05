using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnRate = 1f;

	void Start() {
		Spawn ();
	}

	// Use this for initialization
	void Spawn () {
		Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
		Invoke("Spawn", spawnRate);
		//Invoke("Spawn", Random.Range(spawnMin, spawnMax ));
	}

}
