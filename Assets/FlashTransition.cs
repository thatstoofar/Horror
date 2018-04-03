using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashTransition : MonoBehaviour {

	public Image image;
	Color c;
	bool increase;
	// Use this for initialization
	void Start () {
		image.color = c;
		c = Color.white;
		c.a = 0f;
		increase = true;
	}

	// Update is called once per frame
	void Update () {
		if (increase == true) {
			if (image.color.a > 0.8f) {
				increase = false;
			} else {
				c.a += 0.2f;
			}
		} else {
			c.a -= 0.05f;
		}
		image.color = c;
	}
}
