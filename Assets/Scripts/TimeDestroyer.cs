using UnityEngine;
using System.Collections;

public class TimeDestroyer : MonoBehaviour
{
	public float lifetime;
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}