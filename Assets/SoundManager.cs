using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*SoundManager
 * this class should manage everything that has to do with sound
 * 
 * 
 * */


public class SoundManager: MonoBehaviour
{
	public AudioClip[] sounds;
// sound effects
	public AudioSource playerSoundSource;
	// the sound source of the player
	public GameObject gameManager;
	// the player
	public bool playerPlaying;
	public bool enemyPlaying;


	public bool stopMusic;

	void Awake ()
	{
	}

	void Update ()
	{
		GameObject enemy = GameObject.Find ("Enemy");
		// player moving play sound
		if (gameManager.GetComponent<GameManager> ().playerMoving && !playerPlaying) {
			print ("walkSound");
			playerPlaying = true;
			playerSoundSource.Play ();
		}
		// player stop mvoing stop sound
		if (!gameManager.GetComponent<GameManager> ().playerMoving) {
			playerPlaying = false;
			playerSoundSource.Stop ();
		}
		if (enemy != null) {

			if (enemy.GetComponent<EnemyController> ().roaring && !enemyPlaying) {
				enemyPlaying = true;
				print (enemy.GetComponent<AudioSource> ().clip = sounds[0]);
				enemy.GetComponent<AudioSource> ().Play (); 
			}
			if (!enemy.GetComponent<EnemyController> ().roaring) {
				enemyPlaying = false;
				playerSoundSource.Stop ();
			}
		}

	}

	public void playSound (AudioClip audioClip, AudioSource soundSource)
	{
		soundSource.PlayOneShot (audioClip);
	}

}