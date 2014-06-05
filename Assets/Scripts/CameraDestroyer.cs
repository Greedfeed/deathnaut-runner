using UnityEngine;
using System.Collections;

public class CameraDestroyer : MonoBehaviour {

	void OnBecameInvisible() {
		if (gameObject.transform.parent) {
			Destroy(gameObject.transform.parent.gameObject);
			//Debug.Log(gameObject.transform.parent);
		}
		else {
			Destroy(gameObject);
			//Debug.Log(gameObject);
		}
	}
}
