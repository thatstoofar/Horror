using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GameManger.cs  
 * 
 * This class is responsible for all game logic 
 * 
 */


public class GameManager : MonoBehaviour
{
	public GameObject jS; // the jump scare
	public GameObject enemy; //  The spawned enemy
	public bool playerMoving; // check if player is moving 
	private GameObject player; // the player
	private GameObject insEnemy; // The instance of a spawned enemy
	public float radius = 50; // radius for creating a spawning circufrance
	public float deathDistance = 1f; // the range where the player gets jump scared 
	public float enemySpeed = 1f; // the speed at which the enemy moves
	private bool inSpawnEnemy; // check if you are still in the method SpawnEnemy
	public float hearingDistance = 10f; // the distance where the monster moves quicker if player moves 
	public float enemySpawnDuration  = 300f; // the living time of the monster
	public float distance = -1; // the distance between the player and the monster
	public Vector3 enemySpawnPosition; // the position the enemy first spawned
	public bool inJumpScare = false; // in couroutine jumpScare


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		insEnemy = enemy;

	}

	// Update is called once per frame
	void Update ()
	{

		if (!inSpawnEnemy) {
			StartCoroutine (spawnEnemy (enemySpawnDuration));
		}
		if (insEnemy != null) {
			distance = Vector3.Distance (insEnemy.transform.position, player.transform.position);
			//player death and jump scare
			if (distance < deathDistance && !inJumpScare) {
				print ("jumpScare");
				StartCoroutine(jumpScare (2f));
			}
			// speeds up enemy if player moving and in hearing range
			if (distance < hearingDistance && playerMoving) {
				insEnemy.GetComponent<EnemyController>().speed += 0.01f;
				print ("move quickly");
			}

			if (distance < hearingDistance ) {
				print ("stop and rotate");
				insEnemy.GetComponent<EnemyController>().canMove = false;
				insEnemy.transform.RotateAround(insEnemy.transform.position,Vector3.up, 20f *Time.deltaTime);
			}





		}

	}

	/*
 * enemySpawner  
 * 
 * This method creates an enemy at a random point within a circumference	 of a given radius
 * 
 */
	void enemySpawner ()
	{
		float a = Random.Range (0f, 361f);
		float x = radius * Mathf.Cos (a * Mathf.Deg2Rad) + player.transform.position.x;
		float z = radius * Mathf.Sin (a * Mathf.Deg2Rad) + player.transform.position.z;
		enemySpawnPosition =  new Vector3(x,transform.position.y, z);
		insEnemy = (GameObject)Instantiate (enemy, new Vector3 (x, transform.position.y, z), new Quaternion ());
		insEnemy.transform.LookAt (player.transform);
		insEnemy.name = "Enemy";
		insEnemy.GetComponent<EnemyController> ().speed = enemySpeed;
		Destroy (insEnemy, enemySpawnDuration);
	}

	/*
 * spawnEnemy  
 * 
 * This method adds a delay to spawning the enemy 
 * @param {float|IEnumerator} delay of spawning next enemy
 * 
 */
	IEnumerator spawnEnemy (float time)
	{
		inSpawnEnemy = true;
		enemySpawner ();
		yield return new WaitForSeconds (time);
		inSpawnEnemy = false;
	}

	/*
 * jumpScare  
 * 
 * This method adds a delay to spawning the enemy 
 * @param {float|IEnumerator} delay of spawning next enemy
 * 
*/
	public void jumpScare(){
		player.SetActive (false);
		GameObject insJumpScare = (GameObject)Instantiate (jS, player.transform.position, new Quaternion ());
	}


	IEnumerator jumpScare(float time){
		inJumpScare = true; 
		player.SetActive (false);
		GameObject insJumpScare = (GameObject)Instantiate (jS, player.transform.position, new Quaternion ());
		yield return new WaitForSeconds(time);
		inJumpScare = false; 
	}
}
