using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Animator anim; 
	public float speed;
	public float turnSpeed;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Screen.SetResolution ((int)Screen.width, (int)Screen.height, true);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.acceleration.y > -0.20f ){
			anim.SetBool ("walking", true);
			transform.Translate ( 0, 0, 1*speed*Time.deltaTime);
		}
		if( Input.acceleration.y < -0.40f ){
			anim.SetBool ("walking", false);
			print("Stop");

		}
		if( Input.acceleration.x > 0.35f ){
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
			print("Rotate Right");

		}
		if( Input.acceleration.x < -0.35f ){
			transform.Rotate (Vector3.down, turnSpeed * Time.deltaTime);
			print("Rotate Left");

		}




	}
}
