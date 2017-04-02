using System.Collections;
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
			if (boxMovement.scorable) {
				ScoreScript.scoreTotal = ScoreScript.scoreTotal + ScoreScript.score;
			
				if (!PlayerPrefs.HasKey("hlscore")) {
					PlayerPrefs.SetFloat ("hlscore", 99999f);
				}
				if (ScoreScript.scoreTotal < PlayerPrefs.GetFloat("hlscore")) {
					PlayerPrefs.SetFloat ("hlscore", ScoreScript.scoreTotal);
				}
			}
			boxMovement.scorable = false;
			animation.Play();
			StartCoroutine(WaitElevator());

		}
	}
	IEnumerator WaitElevator(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("end");
	}
}