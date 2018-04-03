using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerController.cs  
 * 
 * This class is responsible the movement of the enemy creature
 * 
 */
public class EnemyController : MonoBehaviour {
	private Animator anim; 
	private Vector3 target; // the  player's positon
	public float speed; // speed the monster move's 
	public float turnSpeed = 20f; // speed the monster turns
	public bool canMove = true; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	// Update is called once per frame
	void Update () {

		if (canMove) {
			transform.Translate (0, 0, 1 * speed * Time.deltaTime);
		} 

		//target = GameObject.Find ("Player").transform.position;
		//transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
	
	}





}
