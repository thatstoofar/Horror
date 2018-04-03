using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*MainMenuController
 * this method is for all methods within the main menu
 * 
 * */


public class MainMenuController : MonoBehaviour {
	public GameObject cam;
	public GameObject flicker;
	public int level;
	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		print (Screen.orientation);
		if (Input.touchCount > 0){
			SceneManager.LoadScene (level +1);
		}
	}

	IEnumerator NewGame(){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (level +1);
	}
}
