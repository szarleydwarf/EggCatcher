using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSide : MonoBehaviour {
//	public Animator anim;
	public GameObject player;

	private Vector2 newPosition ;
	private float smooth = 1.75f;

	void Update () {
//		bool isLow = anim.GetBool ("getLow");
		if(player.GetComponent<flipMe> ().getIsFacingRight ()){
			newPosition = new Vector2 (1, 0);
			this.transform.position = Vector2.Lerp (this.transform.position, newPosition, Time.deltaTime*smooth);
		}else if(!player.GetComponent<flipMe> ().getIsFacingRight ()){
			newPosition = new Vector2 (-1, 0);
			this.transform.position = Vector2.Lerp (this.transform.position, newPosition, Time.deltaTime*smooth);
		}else{
			newPosition = new Vector2 (0, 0);
			this.transform.position = newPosition;
		}
	}
}
