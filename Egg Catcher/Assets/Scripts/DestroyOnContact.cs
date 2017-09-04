using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log ("Destroing: " + other.tag);
		Destroy (other.gameObject);
		//to be changed later for a pulling method
	}
}
