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
		rb.velocity = new Vector2 (speed + Input.GetAxis ("Horizontal") * acceleration_x, rb.velocity.y);
		transform.Rotate(0, 0, -Input.GetAxis ("Horizontal")*10);
		if (grounded) {
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

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			grounded = true;
		}
	}
}