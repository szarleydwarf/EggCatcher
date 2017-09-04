using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void Start () {
		Instantiate((GameObject)Resources.Load("Prefabs/intro_scene_env"));
		Instantiate((GameObject)Resources.Load("Prefabs/Player_Menu"));
		Instantiate((GameObject)Resources.Load("Prefabs/egg_intro"));
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ShowCredits() {
		
	}

	public void RunGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Settings(){
		
	}
}
