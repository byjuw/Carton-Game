using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour
{
	public float acceleration_x = 10f;
	public float speed = 13f;
	private bool grounded = true;
	public float jump_pressure = 25f;
	public float jump_pressure_max = 25f;
	public float jump_min = 4f;
	private Rigidbody2D rb;
	private GameObject go;
	private float goRot;
	private float goScale;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update()
	{

		goRot = Quaternion.Angle (Quaternion.Euler (new Vector3 (0, 0, 0)), transform.rotation);
		goScale = transform.localScale.y;
		//Horizontal Movement
		rb.velocity = new Vector2 (speed + Input.GetAxis ("Horizontal") * acceleration_x, rb.velocity.y);
		//Rotation
		transform.Rotate (0, 0, -Input.GetAxis ("Horizontal") * 10);

		//Jump
		if (grounded && (goRot < 80 && goRot > -80)) {
			//Chargement jump
			if (Input.GetButton ("Jump")) {

				rb.velocity = new Vector2 (rb.velocity.x, jump_pressure);
				grounded = false;
//				if (jump_pressure < jump_pressure_max) {
//					jump_pressure += Time.deltaTime * 5 * 10f;
//
//
//				}
//				else {
//					jump_pressure = jump_pressure_max;
//				}
			}
//			else {
//				if (jump_pressure > 0f) {
//					jump_pressure += jump_min;
//					rb.velocity = new Vector2 (rb.velocity.x, jump_pressure);
//					jump_pressure = 0f;
//					grounded = false;
//				}
//			}
		}
	}

	//Detection ground
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			grounded = true;
		}
	}
}