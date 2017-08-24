using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayIntro : MonoBehaviour {
	public RawImage image;
	public VideoClip vClip;

	private VideoPlayer vPlayer;

	private VideoSource vSource;
	private AudioSource aSource;

	// Use this for initialization
	void Start () {
//		((MovieTexture)GetComponent <Renderer> ().material.mainTexture).Play ();
		Application.runInBackground = true;
		StartCoroutine (playVideo());
	}

	IEnumerator playVideo() {
		vPlayer = gameObject.AddComponent<VideoPlayer> ();
		aSource = gameObject.AddComponent<AudioSource> ();

		vPlayer.playOnAwake = false;
		aSource.playOnAwake = false;
		aSource.Pause ();

		vPlayer.source = VideoSource.VideoClip;

		vPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		vPlayer.EnableAudioTrack (0, true);
		vPlayer.SetTargetAudioSource (0, aSource);

		vPlayer.clip = vClip;
		vPlayer.Prepare ();

		WaitForSeconds waitTime = new WaitForSeconds (1);
		while(!vPlayer.isPrepared){
//			Debug.Log ("Preparing");
			yield return waitTime;
			break;
		}

//		Debug.Log ("Vid ready");
		image.texture = vPlayer.texture;

		vPlayer.Play ();
		aSource.Play ();
		float duration = (float)vClip.length;
		WaitForSeconds waitTimePlaying = new WaitForSeconds (1);
		while(vPlayer.isPlaying){
			yield return waitTimePlaying;
		}

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
