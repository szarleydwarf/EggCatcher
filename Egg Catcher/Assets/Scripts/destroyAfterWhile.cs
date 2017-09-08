using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterWhile : MonoBehaviour {
	private float delay = 3.0f, min = 0f, max = 1f, dur = 2.75f, startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = (Time.time - startTime) / dur;
		this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (max, min, t));
		Destroy(this.gameObject, delay);
	}
}
