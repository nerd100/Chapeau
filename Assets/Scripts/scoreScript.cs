using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour {		//TODO: Hier noch die Namen anpassen

	public int _playerNumber;
	public GameObject playerTextField;
	public GameObject canvas;
	private int totalPoints;
	int currentPlayerPoints;
	int playerBeforeCurrentPlayerPoints;
	int totalRoundPoints;
	// Use this for initialization
	void Start () {
		totalPoints = 0;
		int x = -275;
		int y = -80;
		_playerNumber = PlayerPrefs.GetInt ("playerNumber");
		for (int i = 1; i <= _playerNumber; i++) {
			totalPoints = 0;
			GameObject playerTextPrefab = Instantiate (playerTextField, Vector3.zero, Quaternion.identity, canvas.transform);
			playerTextPrefab.transform.localPosition = new Vector3 (x, y, 0);
			playerTextPrefab.GetComponent<Text> ().text = wordInputHandler.playerNames[i-1];//"Player "+ i.ToString();
			for (int j = 1; j <= 3; j++) {
				if (i - 1 == 0) {
					int p = _playerNumber;
					currentPlayerPoints = gameScript.get_playerPoints ("Player" + i + "Round" + j);
					playerBeforeCurrentPlayerPoints = gameScript.get_playerPoints ("Player" + p + "Round" + j);
					totalRoundPoints = currentPlayerPoints + playerBeforeCurrentPlayerPoints;
					playerTextPrefab.GetComponent<Text> ().text += "\n\n" + totalRoundPoints;
				} else {
					currentPlayerPoints = gameScript.get_playerPoints ("Player" + i + "Round" + j);
					playerBeforeCurrentPlayerPoints = gameScript.get_playerPoints ("Player" + (i-1) + "Round" + j);
					totalRoundPoints = currentPlayerPoints + playerBeforeCurrentPlayerPoints;
					playerTextPrefab.GetComponent<Text> ().text += "\n\n" + totalRoundPoints;
				}
				totalPoints += totalRoundPoints;
			}
			playerTextPrefab.GetComponent<Text> ().text += "\n\n\n" + totalPoints;
			//playerTextPrefab.GetComponent<Text> ().text = "Player "+ i.ToString() + "\t\t\t" + gameScript.get_playerPoints ("Player " + i);
			x += 140;
			//Debug.Log("Player "+ i + " : "+gameScript.get_playerPoints("Player " + i)+" Points");
		}
	}

	public void backToMenu(){
		mainMenu.playSong = false;
		SceneManager.LoadScene("menu");
	}

}
