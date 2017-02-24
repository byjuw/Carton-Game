using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	private AudioSource kage;
	// Use this for initialization
	void Start () {
		kage = GameObject.Find ("chinchin").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) Application.LoadLevel("lvl1");
	}

	public void onClickStart() {
		kage.Play();
		StartCoroutine(WaitKage());
	}
	IEnumerator WaitKage(){
		yield return new WaitForSeconds(2);

		Application.LoadLevel("lvl1");
	}
}