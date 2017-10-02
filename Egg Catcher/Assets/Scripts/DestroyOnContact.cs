using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyOnContact : MonoBehaviour {
	public GameObject brokenEgg;
	public Text points;
/* public AudioClip clipAmb;
 public AudioClip clipEngine;
 public AudioClip clipWeapon1; 
 public AudioClip clipWeapon2;
 
 private AudioSource audioAmb;
 private AudioSource audioEngine;
 private AudioSource audioWeapon1;
 private AudioSource audioWeapon2;
 

 public void Awake(){
     // add the necessary AudioSources:
     audioAmb = AddAudio(clipAmb, true, true, 0.2);
     audioEngine = AddAudio(clipEngine, true, true, 0.4);
     audioWeapon1 = AddAudio(clipWeapon1, false, false, 0.8);
     audioWeapon2 = AddAudio(clipWeapon2, false, false, 0.8); 
     } */
	public AudioClip audioBrokenEgg, audioLifeUp, audioCatch, audioGameOver;

	public AudioSource sourceBrokenEgg, sourceLifeUp, sourceCatch, sourceGameOver;

	private int score = 0, lifes = 3, maxLifes= 10, lifeUp = 100;
	private float spawnTimer = 0;

	void Start(){
		maxLifes = GameObject.Find ("GameController").GetComponent<GameController> ().getMaxLifes ();
		sourceLifeUp = AddAudio(audioLifeUp, false, false, 1);
		sourceBrokenEgg = AddAudio(audioBrokenEgg, false, false, 1);
		sourceCatch = AddAudio(audioCatch, false, false, 1);
		sourceGameOver = AddAudio(audioGameOver, false, false, 1);
	}

	
	void OnTriggerEnter2D(Collider2D other){
		spawnTimer = GameObject.Find ("GameController").GetComponent<GameController> ().getSpawnTimer();
		lifes = GameObject.Find ("GameController").GetComponent<GameController> ().getCurrentLifes ();

		if(this.name.CompareTo ("Basket_B")==0){
			score++;
			points.text = "SCORE: " + score;
			sourceCatch.Play();
			int modulo = score % lifeUp;
			if(modulo == 0 && lifes < maxLifes){
				sourceLifeUp.Play();
				lifes++;

			}
			if(spawnTimer > 0.5f && (modulo/2) == 0){
				spawnTimer -= 0.1f;
			}

		}else {
			lifes--;
			sourceBrokenEgg.Play();
			Instantiate (brokenEgg, new Vector2 (other.transform.position.x, other.transform.position.y),Quaternion.identity);
		}
		if(lifes <= 0){
			sourceGameOver.Play();
		}

		GameObject.Find ("GameController").GetComponent<GameController> ().setCurrentLifes (lifes);
		GameObject.Find ("GameController").GetComponent<GameController> ().setSpawnTimer (spawnTimer);
		GameObject.Find ("GameController").GetComponent<GameController> ().updateLifes ();
		Destroy (other.gameObject);
	}

	int computeLifesUp(int score, double growthModifier){
		return (int)((score * 10) * (score * growthModifier));
	}

	public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) { 
	     AudioSource newAudio = gameObject.AddComponent<AudioSource>();
	     newAudio.clip = clip; 
	     newAudio.loop = loop;
	     newAudio.playOnAwake = playAwake;
	     newAudio.volume = vol; 
	     return newAudio; 
  	}
 
}
