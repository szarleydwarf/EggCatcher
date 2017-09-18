using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pauseGame(){
		bool isPaused = GameObject.Find ("GameController").GetComponent<GameController> ().getIsPaused ();
		GameObject.Find ("GameController").GetComponent<GameController> ().setIsPaused (!isPaused);
	}
}
