using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Animator anim; 
	private Vector3 target;
	public float speed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	// Update is called once per frame
	void Update () {
		target = GameObject.Find ("Player").transform.position;
		anim.SetBool ("running", true);
		//transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		transform.Translate ( 0, 0, 1*speed*Time.deltaTime);
	}





}
