using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class ScoreHL : MonoBehaviour {

	Text text;

	void Awake(){
		text = GetComponent <Text> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		text.text = "" + PlayerPrefs.GetFloat("hlscore");
	}
}