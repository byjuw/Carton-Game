using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishlv2 : MonoBehaviour {
	private Animation animation;

	public static float hlScorelvl2;

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
			hlScorelvl2 = ScoreScript.scorelvl2;
			ScoreScript.scoreTotal += ScoreScript.scorelvl2;
			if (hlScorelvl2 < PlayerPrefs.GetFloat("hlScorelvl2")) {
				PlayerPrefs.SetFloat ("hlScorelvl2", hlScorelvl2);
			}
			if (ScoreScript.scoreTotal < PlayerPrefs.GetFloat ("hlScoreTotal")) {
				PlayerPrefs.SetFloat ("lhScoreTotal", ScoreScript.scoreTotal);
			}
			animation.Play();
			StartCoroutine(WaitElevator());

		}
	}
	IEnumerator WaitElevator(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("end");
	}
}