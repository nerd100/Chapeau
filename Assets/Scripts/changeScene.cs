using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
	
	public GameObject audio;
	string preGameProp = "preGameProp";
	public static List<string> test = new List<string>();
	public float tempVolume;

	void Start (){
		audio = GameObject.FindGameObjectWithTag ("audio");
	}

	public void loadScene(){
		tempVolume = PlayerPrefs.GetFloat ("volume", 0.0f);	//die Lautstärke soll nicht bei jedem Neustart zurückgesetzt werden
		PlayerPrefs.DeleteAll(); //delete Scores and Words from last round
		PlayerPrefs.SetFloat ("volume", tempVolume);
		DontDestroyOnLoad (audio); //play the song
		SceneManager.LoadScene(preGameProp);
	}
	public void exitGame(){
		Application.Quit();
	}

}
