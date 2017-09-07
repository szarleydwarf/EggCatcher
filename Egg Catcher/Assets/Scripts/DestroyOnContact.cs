using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if(this.name.CompareTo ("Basket_B")==0){
//			Debug.Log ("ADD point" );
		}else {
			Debug.Log ("Sub point "+this.name);
			//change to broken egg
		}


		Destroy (other.gameObject);
		//to be changed later for a pulling method
	}
}
