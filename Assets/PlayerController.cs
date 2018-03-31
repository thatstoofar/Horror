using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Animator anim; 
	public float speed;
	private GameObject target; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Screen.SetResolution ((int)Screen.width, (int)Screen.height, true);
		target = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = target.transform.position;
		if( Input.acceleration.y > -0.20f ){
			anim.SetBool ("walking", true);
			transform.Translate ( 0, 0, 1*speed*Time.deltaTime);
		}
		if( Input.acceleration.y < -0.40f ){
			anim.SetBool ("walking", false);
			print("Stop");

		}
	}
}
