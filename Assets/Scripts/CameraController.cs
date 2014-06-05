using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Transform player;
	float playerOffset;

	// Use this for initialization
	void Start () {
		GameObject playerObj = GameObject.FindGameObjectWithTag ("Player");

		player = playerObj.transform;

		playerOffset = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + playerOffset;
			transform.position = pos;
		}
		else {
			Vector3 pos = transform.position;
			pos.x = transform.position.x + 0.05f;
			transform.position = pos;
		}
	}
}
