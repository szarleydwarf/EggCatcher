using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
//	public GameObject Env;

	private int lifes = 3;
	// Use this for initialization
	void Start () {
		Instantiate((GameObject)Resources.Load("Prefabs/EnvGame"));
		Instantiate((GameObject)Resources.Load("Prefabs/PlayerGame"));
//		Instantiate((GameObject)Resources.Load("Prefabs/ShacksGame"));
//		for (int i = 0; i < lifes; i++) {
//			GameObject egg = (GameObject)Resources.Load ("Prefabs/egg_life");
//			egg.transform.position = new Vector2 (-5 + i, 4);
//			Instantiate (egg);
//		}

		MainLoop ();
	}
	
	// Update is called once per frame
	void MainLoop () {
		
	}
}
