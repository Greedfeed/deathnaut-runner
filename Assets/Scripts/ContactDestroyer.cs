using UnityEngine;
using System.Collections;

public class ContactDestroyer : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{	
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
		} else {
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

		/*
		if (other.gameObject.transform.parent) {
			Destroy(other.gameObject.transform.parent.gameObject);
			Debug.Log("Other gameobject");
		}
		else {
			Destroy(other.gameObject);
			Debug.Log(other.gameObject);
		}*/
	}
}
