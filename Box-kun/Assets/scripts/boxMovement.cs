using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour
{
	public float acceleration_x = 10f;
	public float speed = 10f;
	private bool grounded = true;
	private float jump_pressure = 0f;
	private float jump_pressure_max = 10f;
	private float jump_min = 2f;
	private Rigidbody2D rb;
	int rotCount = 0;
	bool rotating = false;

	// tags that can destroy the sub
	public string[] destroyers;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update()
	{
		//Horizontal Movement
		rb.velocity = new Vector2 (speed + Input.GetAxis ("Horizontal") * acceleration_x, rb.velocity.y);

		//Rotation
		if (!rotating && Input.GetKeyDown(KeyCode.LeftArrow)) {
			rotCount = (rotCount + 1) % 4;
			DoRotation();
		}

		if (!rotating && Input.GetKeyDown(KeyCode.RightArrow)) {
			rotCount = (rotCount - 1) % 4;
			DoRotation();
		}


		//Jump
		if (grounded && rotCount ==0 && !rotating) {
			//Chargement jump
			if (Input.GetButton ("Jump")) {
				if (jump_pressure < jump_pressure_max) {
					jump_pressure += Time.deltaTime * 10f;
				}
				else {
					jump_pressure = jump_pressure_max;
				}
			}
			else {
				if (jump_pressure > 0f) {
					jump_pressure += jump_min;
					rb.velocity = new Vector2 (rb.velocity.x, jump_pressure);
					jump_pressure = 0f;
					grounded = false;
				}
			}
		}
	}

	//Detection ground
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			grounded = true;
		}
	}

	void DoRotation() {
		rotating = true;
		var rot = rotCount * 90.0;
		iTween.RotateTo(gameObject, iTween.Hash("z",rot, "oncomplete","EndRotation", "time",0.5));
	}

	void EndRotation() {
		rotating = false;
	}
}