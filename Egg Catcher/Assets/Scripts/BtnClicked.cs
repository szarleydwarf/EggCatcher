using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClicked : MonoBehaviour {

	public AudioClip audioClip;

	public AudioSource source;

	void Start () {
		source.clip = audioClip;
	}

	public void PlayOnClick () {
		source.Play();
	}
}
