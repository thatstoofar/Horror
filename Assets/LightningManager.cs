using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningManager : MonoBehaviour {
	public ParticleSystem lightning;
	public GameObject flashCanvas;
	ParticleSystem currentLightning;
	GameObject currentFlash;

	float stoptimer;
	bool activation; 
	// Use this for initialization
	void Start () {
		stoptimer = 5f;
		activation = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activation == false) {
			activate ();
			activation = true;
			stoptimer = 5f;
		}

		if (stoptimer < 0f) {
			activation = false;
			deactivate ();
		}

		stoptimer -= Time.deltaTime;
		Debug.Log (activation);
		Debug.Log (stoptimer);
	}

	void activate() {
		currentLightning = Instantiate (lightning, new Vector3(0, 45, 0), new Quaternion());
		currentFlash = (GameObject)Instantiate (flashCanvas); 
	}

	void deactivate() {
		Destroy (currentLightning.gameObject);
		Destroy (currentFlash.gameObject);
	}

}
