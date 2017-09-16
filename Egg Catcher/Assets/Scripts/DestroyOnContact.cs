using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyOnContact : MonoBehaviour {
	public GameObject brokenEgg;
	public Text points;

	private int score = 0, lifes = 3, maxLifes= 0, lifeUp = 1;
	double growthModifier = 0.5;
	void Start(){
		maxLifes = GameObject.Find ("GameController").GetComponent<GameController> ().getMaxLifes ();
//		lifeUp = computeLifesUp (score, 1.5);
	}

	void OnTriggerEnter2D(Collider2D other){
		lifes = GameObject.Find ("GameController").GetComponent<GameController> ().getCurrentLifes ();
		if(this.name.CompareTo ("Basket_B")==0){
//			Debug.Log ("ADD point" );
			score++;
			points.text = "SCORE: " + score;

			Debug.Log ("lifeUp " + lifeUp + " / " + score);
			if(score % lifeUp == 0 && lifes < maxLifes){
				lifes++;
				lifeUp = computeLifesUp (score, growthModifier);
			}

		}else {
			lifes--;
			Instantiate (brokenEgg, new Vector2 (other.transform.position.x, other.transform.position.y),Quaternion.identity);
		}
		GameObject.Find ("GameController").GetComponent<GameController> ().setCurrentLifes (lifes);
		GameObject.Find ("GameController").GetComponent<GameController> ().updateLifes ();
		Destroy (other.gameObject);
	}

	int computeLifesUp(int score, double growthModifier){
		return (int)((score * 10) * (score * growthModifier));
	}
}
