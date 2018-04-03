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
	public SoundManager sm;
	public float speed; // speed the monster move's 
	public float turnSpeed = 20f; // speed the monster turns
	public bool canMove = true; // can move
	public bool turning= false;  // turning 
	public bool walkBack= false; // condition for walking away
	public bool roaring = false; // roaring 
	private bool inTurnAround;
	private bool inTurning;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		inTurning = false;

	
	}
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("Player");
		if (canMove) {
			anim.SetBool ("running", true);
			transform.Translate (0, 0, 1 * speed * Time.deltaTime);
			transform.LookAt (player.transform);
		} 
		if (walkBack) {
			anim.SetBool ("running", true);
			transform.Translate (0, 0, 1 * speed * Time.deltaTime);
		} 
		if (turning && !inTurning) {
			inTurning = true;
			GameObject gm = GameObject.Find ("GameManager");
			anim.Play ("creature1roar");
			roaring = true;
			if (!inTurnAround) {
				StartCoroutine (turnAround (gm, gm.GetComponent<GameManager>().rotateTime));
			}
		}

	
	}


	IEnumerator turnAround(GameObject gm, float time){
		inTurnAround = true;
		transform.RotateAround (transform.position, Vector3.up, 30 * Time.deltaTime);
		yield return new WaitForSeconds (time);
		transform.LookAt (gm.GetComponent<GameManager>().enemySpawnPosition);
		anim.Play ("creature1run");
		inTurnAround = false;
	}


}
