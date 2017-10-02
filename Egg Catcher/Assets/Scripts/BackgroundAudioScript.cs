using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioScript : MonoBehaviour {

	public AudioClip audioClip;

	public AudioSource source;

	void Start () {
		source.clip = audioClip;
		source.volume = 0.4f;
		source.Play();
	}
}
