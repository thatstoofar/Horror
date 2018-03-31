using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject enemy;
	public bool redlight; 
	private GameObject target;
	public float radius; 
	public float enemySpeed;
	private bool inSpawnEnemy;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!inSpawnEnemy) {
			StartCoroutine (spawnEnemy(10f));
		}
	}

	void enemySpawner(){
		float a = Random.Range (0f, 361f);
		float x = radius * Mathf.Cos (a*Mathf.Deg2Rad) + target.transform.position.x;
		float z = radius * Mathf.Sin (a*Mathf.Deg2Rad) + target.transform.position.z;
		GameObject se = (GameObject)Instantiate (enemy, new Vector3 (x,transform.position.y,z), new Quaternion());
		se.transform.LookAt (target.transform);
		se.GetComponent<EnemyController> ().speed = enemySpeed;
		Destroy (se, 10f);
	}

	IEnumerator spawnEnemy(float time){
		inSpawnEnemy= true;
		enemySpawner ();
		yield return new WaitForSeconds (time);
		inSpawnEnemy = false;
	}


}
