﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishlv2 : MonoBehaviour {
	private Animation animation;

	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation>();

	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			animation.Play();
			StartCoroutine(WaitElevator());

		}
	}
	IEnumerator WaitElevator(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("end");
	}
}