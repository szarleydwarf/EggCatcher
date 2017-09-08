using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnContact : MonoBehaviour {
	public GameObject brokenEgg;

	void OnTriggerEnter2D(Collider2D other){
		if(this.name.CompareTo ("Basket_B")==0){
			Debug.Log ("ADD point" );
		}else {
			Instantiate (brokenEgg, new Vector2 (Random.Range (-7f, 7f), Random.Range (-4.25f, -4.75f)),Quaternion.identity);
		}
		Destroy (other.gameObject);
		//to be changed later for a pulling method
	}


}
