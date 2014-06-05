using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {
	public float maxSpeed = 3f;

	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 250f;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {  
		rigidbody2D.velocity = new Vector2 (maxSpeed, rigidbody2D.velocity.y);

		grounded = Physics2D.OverlapCircle (groundCheck.position,groundRadius,whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
	}

	void Update(){

		GameObject[] shots = GameObject.FindGameObjectsWithTag("Bolt");
		int shotNum = shots.Length;

		// ANDROID CONTROLS 
		/*
		if (Input.touches.Length >= 1)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				var touch = Input.GetTouch(i);

				if (grounded && (touch.position.x < Screen.width/2) && Input.GetTouch(i).phase == TouchPhase.Began)
				{
					anim.SetBool("Ground", false);
					
					rigidbody2D.AddForce(new Vector2(0, jumpForce));
				}
				else if (((touch.position.x > Screen.width/2) && Time.time > nextFire) && shotNum < 3 )
				{
					nextFire = Time.time + fireRate;
					
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}
			}
		}*/
		
		
		// WINDOWS CONTROLS/*
		if ( (Input.GetButton("Fire1") && Time.time > nextFire) && shotNum < 3 ) {
			nextFire = Time.time + fireRate;

			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
			

		if (grounded && ( Input.GetKeyDown (KeyCode.Space) )) {
			anim.SetBool("Ground", false);

			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

}
