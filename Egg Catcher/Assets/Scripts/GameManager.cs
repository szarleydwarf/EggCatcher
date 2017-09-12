using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject[] eggs;
	public GameObject[] spPoints;

	private int lifes = 3;
	private float instantiateTimer = 2f;

	// Use this for initialization
	void Awake () {
		drawLifes ();
	}

	public void setLifes(int lifeNum){
		lifes = lifeNum;
		drawLifes ();
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

	void drawLifes() {
		Debug.Log ("Lifes "+lifes);
		for (int i = 0; i < lifes; i++) {
			GameObject egg = (GameObject)Resources.Load ("Prefabs/egg_life");
			egg.transform.position = new Vector2 (-6.2f + (float)i, 4.75f);
			Instantiate (egg);
		}
	}
}
