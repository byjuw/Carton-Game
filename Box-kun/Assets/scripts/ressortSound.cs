using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ressortSound : MonoBehaviour {

	private AudioSource ressort;

	void Start () {
		ressort = GameObject.Find ("RessortEffect").GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player"){
			ressort.Play();
		}
	}
}