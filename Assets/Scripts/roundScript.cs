using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class roundScript : MonoBehaviour {

	public static List<string> roundList;
	public static List<string> tempList;
	public Text timerText;
	public float timer;
	public Text currWord;
	private int firstWordInList;
	bool isPlaying = true;
	public int wordCounter;
	public int wordCount;
	public int _playerNumber;
	private int currRound;
	public Text roundText;


	//Music
	public AudioClip otherClip;
	public GameObject audioPrefab;
	public static bool playSong = false;
	public AudioMixer audioMixer;

	void Start () {
		playSong = false;
		wordCounter = 0;
		firstWordInList = 0;
		roundList = new List<string> ();
		roundList = gameScript.randomList;
		timer = PlayerPrefs.GetInt ("time");
		timerText.text = timer.ToString();
		currWord.text = roundList [firstWordInList];
		wordCount = roundList.Count;
		_playerNumber = gameScript.playerNumber;
		currRound = gameScript.round;
		roundText.text = "Round " + currRound.ToString ();
		Destroy (GameObject.FindGameObjectWithTag ("audio"));
	}

	void Update()
	{
		if (isPlaying) {//wenn Runde gestartet, aktiviere Timer 
			timer -= Time.deltaTime;
			timerText.text = Mathf.RoundToInt (timer).ToString ();
			if (timer <= 0) {
				gameScript.nextPlayer ();
				Destroy (transform.parent.gameObject);
			}
			if (timer <= 5 && playSong == false) {
				GameObject audioGameObject = Instantiate (audioPrefab, Vector3.zero, Quaternion.identity,this.transform);
				audioGameObject.GetComponentInChildren<AudioSource> ().clip = otherClip;
				audioGameObject.GetComponentInChildren<AudioSource> ().Play ();
				playSong = true;
			}
		}
	}

	public void nextWord(){//Wort wurde erraten und nächstes wird geholt, falls vorhanden
		//Debug.Log ("counter "+ roundList.Count);
		gameScript.set_player("Player" + _playerNumber + "Round"+gameScript.round);
		wordCounter += 1;
		if(wordCounter < wordCount){
			//gameScript.test.Add(roundList[firstWordInList]);
			roundList.RemoveAt (firstWordInList);
			currWord.text = roundList[firstWordInList];
		}else{
			roundList.RemoveAt (firstWordInList);
			gameScript.nextPlayer ();
			gameScript.nextRound();
			Destroy (transform.parent.gameObject);

		}
	}
	public void surrender(){//spieler hat einen Fehler gmacht und muss das Wort zurücklegen
		Debug.Log ("wordCounter :" + roundList.Count);
		gameScript.nextPlayer ();
		Destroy (transform.parent.gameObject);
	}
}
