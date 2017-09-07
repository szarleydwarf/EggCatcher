using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
//	public GameObject Env;
	public GameObject[] eggs;
	public GameObject[] spPoints;

	private int lifes = 3;
	private float instantiateTimer = 2f;

	// Use this for initialization
	void Awake () {
//		SO = GetComponent<SpawnObject> ();
//		Instantiate((GameObject)Resources.Load("Prefabs/EnvGame"));
//		Instantiate((GameObject)Resources.Load("Prefabs/PlayerGame"));
////		Debug.Log ("Awake");
//		Instantiate((GameObject)Resources.Load("Prefabs/ShacksGame"));
//		for (int i = 0; i < lifes; i++) {
//			GameObject egg = (GameObject)Resources.Load ("Prefabs/egg_life");
//			egg.transform.position = new Vector2 (-5 + i, 4);
//			Instantiate (egg);
//		}
	}


	void Update() {
		instantiateTimer -= Time.deltaTime;
		if(instantiateTimer <= 0) {
			int randomNumber = Random.Range (0, eggs.Length);
			int randomSP = Random.Range (0, spPoints.Length);

			Vector2 spPos = spPoints [randomSP].transform.position;
			GameObject egg = eggs[randomNumber];
			Instantiate (egg, spPos, Quaternion.identity);
			instantiateTimer = 2f;
		}
	}
}
