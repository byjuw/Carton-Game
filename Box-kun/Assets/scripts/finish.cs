using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour {
	private Animation animation;

	public static float hlScorelvl1;

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
			boxMovement.scorable = false;
			ScoreScript.scoreTotal = ScoreScript.scorelvl1;
			if (ScoreScript.scoreTotal < PlayerPrefs.GetFloat("hlScorelvl1")) {
				PlayerPrefs.SetFloat ("hlScorelvl1", ScoreScript.scoreTotal);
			}
			animation.Play();
			StartCoroutine(WaitElevator());

		}
	}
	IEnumerator WaitElevator(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("lvl2");
	}
}
