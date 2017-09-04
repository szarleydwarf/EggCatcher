using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipMe : MonoBehaviour {

	private bool facingRight = false, isLow = false;
	public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 tcp =  GetTouchClickPosition ();

		if (tcp == Vector2.zero)
			return;

		if(tcp.x < 0 && !facingRight){
			FlipMeNow (180, -3);
		} else if(tcp.x >= 0 && facingRight){
			FlipMeNow (0, 3);
		}
			
		if(tcp.y< 0 && !isLow){
			getLow (tcp.y);
		}else if(tcp.y >= 0 && isLow){
			getLow (tcp.y);
		}
	}

	void getLow (float position) {
		isLow = !isLow;
		anim.SetBool ("getLow", isLow);
		Debug.Log("Get Low" + position);
	}

	void FlipMeNow (int rotation, int position) {
		facingRight = !facingRight;
		transform.rotation = Quaternion.Euler (0, rotation, 0);
//		transform.position = new Vector2 (position, -0.2f);
	}

	Vector3 GetTouchClickPosition () {
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			if(Input.GetMouseButtonDown(0))
				return Camera.main.ScreenToWorldPoint (Input.mousePosition);
		} else if(SystemInfo.deviceType == DeviceType.Handheld) {
			if(Input.touchCount == 1){
				return Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			}
		}
		return Vector3.zero;
	}
}
