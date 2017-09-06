using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public Transform spawningPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void printSomething(){
		Debug.Log ("LOL");
	}
	public void Spawn(GameObject go){
		Debug.Log ("Spawn\n" + go.name + " " + spawningPoint.position.ToString ());
//		Instantiate (go, spawningPoint.position, Quaternion.identity);
	}
}
