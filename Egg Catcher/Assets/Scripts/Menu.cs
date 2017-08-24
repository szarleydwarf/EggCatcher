﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

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
