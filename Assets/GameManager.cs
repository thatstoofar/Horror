using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
	public GameObject player; // the player, for every new scene you must attach the player within that scene
	private GameObject insEnemy; // The instance of a spawned enemy
	public float radius = 50; // radius for creating a spawning circufrance
	public float deathDistance = 1f; // the range where the player gets jump scared 
	public float enemySpeed = 1f; // the speed at which the enemy moves
	private bool inSpawnEnemy; // check if you are still in the method SpawnEnemy
	public float hearingDistance = 10f; // the distance where the monster moves quicker if player moves 
	public float enemySpawnDuration  = 300f; // the living time of the monster
	public float distance = 50f; // the distance between the player and the monster
	public Vector3 enemySpawnPosition; // the position the enemy first spawned
	public bool inJumpScare = false; // in couroutine jumpScare
	public float walkBackTime = 0f; // The timer for walki	ng back
	public float rotateTime = 4f; // time allowed for monster rotating
	public float stopDistance = 10f; // the distance where the monster stops for the plyaer
	public bool walkingBack = false;
	public int enemyCount = 0;
	public bool inRemoveEnemy;


	// Use this for initialization
	void Start ()
	{
		insEnemy = enemy;
		walkingBack = false;
	}

	// Update is called once per frame
	void Update ()
	{

		if (!inSpawnEnemy && enemyCount < 1) {
			StartCoroutine (spawnEnemy (enemySpawnDuration));
		}
		if (insEnemy != null) {
			distance = Vector3.Distance (insEnemy.transform.position, player.transform.position);
			//player death and jump scare
			if (distance < deathDistance && !inJumpScare) {
				print ("jumpScare");
				StartCoroutine(jumpScare (2.5f));
			}
			// speeds up enemy if player moving and in hearing range
			if (distance < hearingDistance && playerMoving) {
				
			}
			// stop and rotate 
			if (distance < hearingDistance && !walkingBack) {
				if (playerMoving && !inJumpScare) {
					StartCoroutine (jumpScare (2.5f));
				}
				walkBackTime += Time.deltaTime;
				insEnemy.GetComponent<EnemyController>().canMove = false;
				insEnemy.GetComponent<EnemyController>().turning = true;

			}
			// walk back home 
			if (walkBackTime > rotateTime && walkBackTime < rotateTime+1) {
				walkingBack = true;
				walkBackTime = 0f;
				insEnemy.GetComponent<EnemyController>().roaring = false;
				insEnemy.GetComponent<EnemyController>().turning = false;
				insEnemy.GetComponent<EnemyController> ().walkBack = true;
				if (!inRemoveEnemy) {
					StartCoroutine (removeEnemy(enemySpawnDuration, enemyCount, insEnemy));
				}
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
		print ("spawn");
		enemyCount++;
		insEnemy = (GameObject)Instantiate (enemy, new Vector3 (x, transform.position.y, z), new Quaternion ());
		insEnemy.transform.LookAt (player.transform);
		insEnemy.name = "Enemy";
		insEnemy.GetComponent<EnemyController> ().speed = enemySpeed;
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
	IEnumerator jumpScare(float time){
		inJumpScare = true; 
		player.SetActive (false);
		insEnemy.SetActive (false);
		GameObject insJumpScare = (GameObject)Instantiate (jS, player.transform.position, new Quaternion ());
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene ("GameOver");
		inJumpScare = false; 
	}
	IEnumerator removeEnemy(float time, int enemyCount, GameObject insEnemy){
		inRemoveEnemy = true;
		yield return new WaitForSeconds (time);
		Destroy (insEnemy);
		walkingBack = false;
		GameObject ec = GameObject.Find ("GameManager");
		ec.GetComponent<GameManager>().enemyCount--;
		print (enemyCount);
		print ("mins");
		inRemoveEnemy = false;
	}


}
