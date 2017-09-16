using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] eggs, lifesEggs;
	public GameObject[] spPoints;

	private int maxLifes = 10, currentLifes = 3;
	private float instantiateTimer = 2f;

	// Use this for initialization
	void Awake () {
		lifesEggs = new GameObject[maxLifes];
		instantiateLifes ();
	}

	public void setCurrentLifes(int lifeNum){
		currentLifes = lifeNum;
	}

	public int getMaxLifes () {
		return maxLifes;
	}
	public int getCurrentLifes () {
		return currentLifes;
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

	void instantiateLifes() {
		for (int i = 0; i < lifesEggs.Length; i++) {
			lifesEggs [i] = Instantiate((GameObject)Resources.Load ("Prefabs/eggLife"),Vector2.zero, Quaternion.identity) as GameObject;
			lifesEggs [i].transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			lifesEggs [i].transform.position = new Vector2 (100f + ((float)i*30), 460f);
			if(i < 3)
				lifesEggs [i].GetComponent<Image> ().enabled = true;
			else
				lifesEggs [i].GetComponent<Image> ().enabled = false;
		}
	}

	public void drawLifes() {
		for (int i = 0; i < lifesEggs.Length; i++) {
			lifesEggs[i].transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			lifesEggs[i].transform.position = new Vector2 (100f + ((float)i*30), 460f);
		}
	}

	public void updateLifes(){
//		Debug.Log ("Update "+currentLifes);
		for(int i = 0; i < lifesEggs.Length; i++){
			if(i < currentLifes)
				lifesEggs [i].GetComponent<Image> ().enabled = true;
			else
				lifesEggs [i].GetComponent<Image> ().enabled = false;
		}
		drawLifes ();
	}
}
