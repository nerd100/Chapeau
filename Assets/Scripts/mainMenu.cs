using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {
	
	public AudioClip otherClip;
	public GameObject audioPrefab;
	public static bool playSong = false;
	public AudioMixer audioMixer;
	public Slider MusicSlider;
	// Use this for initialization

	void Start () {
		if (playSong == false) { //falls der Song nicht gespielt wird, dann starte ihn
			Debug.Log ("WHAT1");
			audioMixer.SetFloat ("volume", PlayerPrefs.GetFloat ("volume", 0.0f));
			//MusicSlider.value = PlayerPrefs.GetFloat ("volume", 0.0f);
			GameObject audioGameObject = Instantiate (audioPrefab, Vector3.zero, Quaternion.identity);
			audioGameObject.GetComponentInChildren<AudioSource> ().clip = otherClip;
			audioGameObject.GetComponentInChildren<AudioSource> ().Play ();
			playSong = true;
		} 

	}
		
}
