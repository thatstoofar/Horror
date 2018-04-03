using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerController.cs  
 * 
 * This class is responsible the movement of the player
 * 
 */

public class PlayerController : MonoBehaviour
{
	public GameManager gm;
	private Animator anim;
	public float speed =1f;
	// the speed the player moves forward
	public float turnSpeed = 20f;
	// the speed which the player turns
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		Screen.SetResolution ((int)Screen.width, (int)Screen.height, true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//walk forward accelermeter
		if (Input.touchCount > 0) {
			gm.playerMoving = true;
			anim.SetBool ("walking", true);
			transform.Translate (0, 0, 1 * speed * Time.deltaTime);	
		}
		// stop 
		if (Input.touchCount == 0) {
			gm.playerMoving = false;
			anim.SetBool ("walking", false);
		}

		/*
		// walk forward accelermeter
		if (Input.acceleration.y > -0.20f) {
			gm.playerMoving = true;
			anim.SetBool ("walking", true);
			transform.Translate (0, 0, 1 * speed * Time.deltaTime);
		}
		// stop moving 
		if (Input.acceleration.y < -0.40f) {
			gm.playerMoving = false;
			anim.SetBool ("walking", false);
		} */
		// turn right 
		if (Input.acceleration.x > 0.35f) {
			//gm.playerMoving = true;
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);

		}
		// turn left
		if (Input.acceleration.x < -0.35f) {
			//gm.playerMoving = true;
			transform.Rotate (Vector3.down, turnSpeed * Time.deltaTime);
			;

		}





	}
}
