using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditLoad : MonoBehaviour {

	public Animation creditLoading;

	public void Awake() {
		creditLoading = GetComponent<Animation> ();



	}
	// Use this for initialization
	void Start () {
		creditLoading.wrapMode = WrapMode.Once;
		creditLoading.Play();
	}
	
	// Update is called once per frame
	void Update () {
		print (creditLoading.isPlaying);
	}
}

