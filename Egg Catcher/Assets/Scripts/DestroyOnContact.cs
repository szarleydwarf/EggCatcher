using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyOnContact : MonoBehaviour {
	public GameObject brokenEgg;
	public Text points;

	private int score = 0, lifes = 3;

	void OnTriggerEnter2D(Collider2D other){
		if(this.name.CompareTo ("Basket_B")==0){
//			Debug.Log ("ADD point" );
			score++;
			points.text = "SCORE: " + score;
		}else {
			lifes--;
			Instantiate (brokenEgg, new Vector2 (other.transform.position.x, other.transform.position.y),Quaternion.identity);
			GameObject.Find ("GameManager").GetComponent<GameManager> ().setLifes (lifes);
		}
		Destroy (other.gameObject);
	}


}
