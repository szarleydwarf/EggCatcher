using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] eggs, lifesEggs;
	public GameObject[] spPoints;
	public GameObject pauseScreen;
	public GameObject gameOverText, restartBtn, quitBtnOnRestart;

	private int maxLifes = 10, currentLifes = 3, lastSP = 0;
	private float instantiateTimer, spawnTimer = 3f;
	private bool isPaused = true, isGameOver = false;

	// Use this for initialization
	void Awake () {
		lifesEggs = new GameObject[maxLifes];
		instantiateTimer = spawnTimer;
		instantiateLifes ();
	}

	public void setCurrentLifes(int lifeNum){
		currentLifes = lifeNum;
	}
	public int getCurrentLifes () {
		return currentLifes;
	}

	public void setSpawnTimer(float num){
		spawnTimer = num;
	}
	public float getSpawnTimer () {
		return spawnTimer;
	}

	public bool getIsGameOver(){
		return isGameOver;
	}
	
	public bool getIsPaused(){
		return isPaused;
	}
		
	public void setIsPaused(bool change){
		isPaused = change;
	}

	public int getMaxLifes () {
		return maxLifes;
	}

	void Update() {
		if (currentLifes > 0) {
			isGameOver = false;
			if (isPaused) {
				instantiateTimer -= Time.deltaTime;
				if (instantiateTimer <= 0) {
					int randomNumber = Random.Range (0, eggs.Length);
					int randomSP = 0;
					
					do {
						randomSP = Random.Range (0, spPoints.Length);
					} while (randomSP == lastSP);
					
					if(randomSP != lastSP)
						lastSP = randomSP;

					Vector2 spPos = spPoints [randomSP].transform.position;
					GameObject egg = eggs [randomNumber];
					Instantiate (egg, spPos, Quaternion.identity);
					instantiateTimer = spawnTimer;
				}

				GameObject[] eggsList = GameObject.FindGameObjectsWithTag ("egg");
				if (eggsList.Length > 0) {
					for (int i = 0; i < eggsList.Length; i++) {
						eggsList [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					}
				}
				pauseScreen.SetActive (false);
			} else {
				// GameObject[] eggsList = GameObject.FindGameObjectsWithTag ("egg");
				// if (eggsList.Length > 0) {
				// 	for (int i = 0; i < eggsList.Length; i++) {
				// 		eggsList [i].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-0.5f, -0.2f));// = RigidbodyConstraints2D.None;
				// 	}
				// }
				removeRestofEggs ();
				pauseScreen.SetActive (true);
			}
		} else{
			removeRestofEggs ();
			isGameOver = true;
			this.gameObject.GetComponent<AudioSource> ().Stop();

			gameOverText.SetActive (true);
			restartBtn.SetActive (true);
			quitBtnOnRestart.SetActive (true);
		}
	}

	void removeRestofEggs(){
		GameObject[] eggsList = GameObject.FindGameObjectsWithTag ("egg");
		for (int i = 0; i < eggsList.Length; i++) {
			//				eggsList[i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			Destroy (eggsList [i].gameObject);
		}
	}

	void instantiateLifes() {
		for (int i = 0; i < lifesEggs.Length; i++) {
			lifesEggs [i] = Instantiate((GameObject)Resources.Load ("Prefabs/eggLife")) as GameObject;
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
