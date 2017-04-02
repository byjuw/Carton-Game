using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreScript : MonoBehaviour {

	public static float score;
	public static float scoreTotal;
	Scene currentScene;
	Text text;


	void Awake(){
		text = GetComponent <Text> ();
		currentScene = SceneManager.GetActiveScene ();
		score = 0;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (currentScene.name != "End") {			
			text.text = "Score : " + score;
		} else {
			text.text = "" + scoreTotal;
		}
	}
}
