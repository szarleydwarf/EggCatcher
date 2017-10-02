using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public GameObject creditsImg, settingsImg, backBtn, okBtn;
	public void Start () {
		Instantiate((GameObject)Resources.Load("Prefabs/intro_scene_env"));
		Instantiate((GameObject)Resources.Load("Prefabs/Player_Menu"));
		Instantiate((GameObject)Resources.Load("Prefabs/egg_intro"));
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ShowCredits() {
		if (creditsImg.activeSelf) {
			creditsImg.SetActive (false);
			backBtn.SetActive (false);
		} else {
			creditsImg.SetActive (true);
			backBtn.SetActive (true);
		}
	}

	public void RunGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Settings(){
		if (settingsImg.activeSelf) {
			settingsImg.SetActive (false);
			okBtn.SetActive (false);
		} else {
			settingsImg.SetActive (true);
			okBtn.SetActive (true);
		}

	}
}
