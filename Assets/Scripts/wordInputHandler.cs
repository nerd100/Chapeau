using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wordInputHandler : MonoBehaviour {

	public int playerNumber;
	public GameObject canvas;
	public GameObject prefab;
	public Dictionary <string, GameObject> playerNotepads; //alle Notpads
	public static List<string> allWords;
	public GameObject[] bigNotepadArray;
	public GameObject warningPanel;
	private GameObject panel;
	public static string[] playerNames;
	public static List<GameObject> smallNotepadList = new List<GameObject> ();
	// Use this for initialization



	void Start () {//Klasse befindet sich um smallNotepad und bigNotepad herum
		smallNotepadList.Clear();
		playerNumber = PlayerPrefs.GetInt ("playerNumber", 3);
		playerNames = new string[playerNumber];
		for (int i = 1; i <= playerNumber; i++) {
			playerNames [i-1] = "Player" + i;
			Debug.Log (playerNames [i-1]);
		}
		playerNotepads = new Dictionary<string, GameObject> ();
		allWords = new List<string> ();

		//PlayerPrefs.GetInt("time");
		instanceNotepad(playerNumber);
		bigNotepadArray = new GameObject[playerNumber];


	}

	public void instanceNotepad(int playerNumber){//hier werden die kleinen notepads erstellt
		int x = -200;
		int y = 500;
		Text[] newText;
		for (int i = 1; i <= playerNumber; i++) {

			if (i % 2 != 0) {
				GameObject notepad = Instantiate (prefab, Vector3.zero, Quaternion.identity, canvas.transform);
				notepad.transform.localPosition = new Vector3 (x, y, 0);
				newText = notepad.GetComponentsInChildren<Text>();
				newText [1].text = playerNames [i-1]; //newText ist ein Array weil er mehrere textField in den Childs gibt
				x = x + 400;
				smallNotepadList.Add (notepad);
			} else {
				GameObject notepad = Instantiate (prefab, Vector3.zero, Quaternion.identity, canvas.transform);
				notepad.transform.localPosition = new Vector3 (x, y, 0);
				newText = notepad.GetComponentsInChildren<Text>();
				newText [1].text = playerNames [i-1];
				x = -200;
				y -= 400;
				smallNotepadList.Add (notepad);
			}
		}
	}
		

	public static void updateNotepadName(int notepadeNumber, string name){
		if (name != "") {
			Text[] updateText;
			updateText = smallNotepadList[notepadeNumber].GetComponentsInChildren<Text> ();
			updateText [1].text = name;
			playerNames [notepadeNumber] = name;
			Debug.Log (playerNames [notepadeNumber]);
		} else {
			playerNames [notepadeNumber] = "Player" + (notepadeNumber+1);
		}
		//updateText = currentSmallNotepade.GetComponentInChildren<Text> ();
		//updateText.text = name;
	}

	public void goButton(){
		bool changeScene = false;
		string wordChain;
		string[] tempArray = new string[3];

		for (int i = 1; i <= playerNumber; i++) {
			wordChain = PlayerPrefs.GetString ("wordsFromPlayer"+i); //Hier wird nichts gefunden
			tempArray = wordChain.Split ('|');
			for(int j = 0; j < 3; j++) {
				if (tempArray[j] != "") {
					allWords.Add (tempArray[j]);
					changeScene = true;
				}
				else {
					changeScene = false;
					allWords.Clear ();
					break;
				}
			}
		}
		if(changeScene == true)
			SceneManager.LoadScene("gameScene");
		else {
			panel = Instantiate (warningPanel, Vector3.zero, Quaternion.identity, canvas.transform);

		}
	}
	public void backToMenu(){
		SceneManager.LoadScene("preGameProp");
	}
}
