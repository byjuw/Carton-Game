using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour {
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
		}
	}
}
