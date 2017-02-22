using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) Application.LoadLevel("lvl1");
	}

	public void onClickStart() {
		Application.LoadLevel("lvl1");
	}
}
