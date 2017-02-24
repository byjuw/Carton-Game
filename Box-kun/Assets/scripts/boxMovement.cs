using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour
{
	public float acceleration_x = 10f;
	private float accelerationJump = 15f;
	public float speed = 10f;
	public float speed2 = -10f;
	private bool grounded = false;
	private bool grounded2 = false;
	private bool jumping = false;
	private bool jumping2 = false;
	public float jump_pressure = 25f;
	public float jump_pressure_max = 25f;
	public float jump_min = 4f;
	private Rigidbody2D rb;
	private GameObject go;
	private float goRot;
	private bool end = false;
	private AudioSource jump;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		jump = GameObject.Find ("Jump").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update()
	{

		goRot = Quaternion.Angle (Quaternion.Euler (new Vector3 (0, 0, 0)), transform.rotation);
		//Horizontal Movement
		if (end) {
			rb.velocity = new Vector2 (0, 0);
		}
		else if (grounded && !jumping && !jumping2) {
			rb.velocity = new Vector2 (speed + Input.GetAxis ("Horizontal") * acceleration_x, rb.velocity.y);
		} else if (grounded2 && !jumping && !jumping2) {
			rb.velocity = new Vector2 (speed2 + Input.GetAxis ("Horizontal") * acceleration_x, rb.velocity.y);
		} else if (jumping) {
			rb.velocity = new Vector2 (speed/5 +  Input.GetAxis ("Horizontal") * accelerationJump, rb.velocity.y);
		} else if (jumping2) {
			rb.velocity = new Vector2 (speed2/5  + Input.GetAxis ("Horizontal") * accelerationJump, rb.velocity.y);
		}

		//Rotation
		transform.Rotate (0, 0, -Input.GetAxis ("Horizontal") * 10);

		//Jump
		if (grounded && (goRot < 80 && goRot > -80)) {
			//Chargement jump
			if (Input.GetButton ("Jump")) {

				rb.velocity = new Vector2 (speed + rb.velocity.x, jump_pressure);
				jumping = true;
				jump.Play();

			}

		} else if (grounded2 && (goRot < 80 && goRot > -80)) {
			if (Input.GetButton ("Jump")) {
				rb.velocity = new Vector2 (speed2 + rb.velocity.x, jump_pressure);
				jumping2 = true;
				jump.Play();
			}
		}
	}


	//Detection ground
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			grounded = true;
			jumping = false;
			jumping2 = false;
		}
		if (coll.gameObject.tag == "ground2") {
			grounded2 = true;
			jumping = false;
			jumping2 = false;
		}
		if (coll.gameObject.tag == "Finish") {
			end = true;
		}
	}
	void OnCollisionExit2D(Collision2D collLeave) 
	{
		if (collLeave.gameObject.tag == "ground") {
			grounded = false;
		}
		if (collLeave.gameObject.tag == "ground2") {
			grounded2 = false;
		}
	}
	}