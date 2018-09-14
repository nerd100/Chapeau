using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallNotepad : MonoBehaviour {

	public string playername;
	public GameObject label;
	public GameObject canvas;
	public GameObject prefab;
	private GameObject GH;

	void Start () {
		canvas = GameObject.FindGameObjectWithTag ("canvas");
		GH = GameObject.FindGameObjectWithTag ("gameHandler");
	}
	public void openBigNotepad(){//öffnet beim click auf kleines notepad das große notepad von Spieler mit Nummer, falls schin vorhanden
		if (GH.GetComponent<wordInputHandler> ().playerNotepads.ContainsKey("bigNotepad_"+playername)) {
			GameObject temp = GH.GetComponent<wordInputHandler> ().playerNotepads["bigNotepad_"+playername];
			temp.SetActive (true);

		} else {//ansonsten wird das notepad erstellt
			PlayerPrefs.SetString ("playername", playername);
			playername = label.GetComponent<Text> ().text;
			GameObject bigNotepad = Instantiate (prefab, Vector3.zero, Quaternion.identity, canvas.transform);
			bigNotepad.transform.localPosition = Vector3.zero;
			bigNotepad.name = "bigNotepad_"+playername;
			bigNotepad.GetComponentInChildren<Text> ().text = playername;
			GH.GetComponent<wordInputHandler> ().playerNotepads.Add (bigNotepad.name, bigNotepad);

		}
	}
}
