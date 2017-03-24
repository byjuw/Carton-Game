using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreScript : MonoBehaviour {

	public static float scorelvl1;
	public static float scorelvl2;
	public static float scoreTotal = 0;

	Text text;

	void Awake(){
		text = GetComponent <Text> ();
		scorelvl1 = 0;
		scorelvl2 = 0;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "lvl1") {			
			text.text = "Score : " + scorelvl1;
		} else if (currentScene.name == "lvl2") {
			text.text = "Score : " + scorelvl2;
		} else if (currentScene.name == "End") {
			text.text = "Score total : " + scoreTotal;
		}
	}
}
