using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Start Game")) 
		{
			Application.LoadLevel(1);
		}
	}
}
