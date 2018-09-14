using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour {

	public GameObject GamePanel;
	public GameObject canvas;

	public static List<string> _wordList;
	public static List<string> randomList;
	public static List<string> test;
	public static int round; 
	public static int playerNumber;
	public static Dictionary <string, int> _playerPoints{ get; set; }

	public static int get_playerPoints(string player)
	{
		return _playerPoints[player];
	}
	public static void set_player(string player)
	{
		_playerPoints[player] += 1;
	}

	public Text playerText;
	public Text roundText;

	private int _playerNumber;

	void Start(){
		_playerNumber = PlayerPrefs.GetInt ("playerNumber");
		round = 1;
		_playerPoints = new Dictionary<string, int>();
		_playerPoints.Clear ();
		for (int i = 1; i <= _playerNumber; i++) {
			for(int j = 1; j <= 3; j++){
				_playerPoints.Add ("Player" + i + "Round"+(j), 0);
			}
		}
		_wordList = new List<string> (wordInputHandler.allWords);
		randomList = new List<string> ();
		//for (int i = 0; i < 2; i++) {
		//	_wordList.Add(i.ToString());
		//}
		//_wordList = wordInputHandler.allWords; //get alle words
		playerNumber = Random.Range (1, _playerNumber+1);
		playerText.text = wordInputHandler.playerNames[playerNumber-1];//"Player " + playerNumber; //startPlayer
		roundText.text = "Round " + round;


		for(int i = 0; i < _wordList.Count; i++){
			randomList.Add (_wordList [i]);
			Debug.Log (randomList [i]);
		}
	}

	void Update(){
		playerText.text = wordInputHandler.playerNames[playerNumber-1]; //startPlayer
		roundText.text = "Round " + round;
		if (round > 3) {
			SceneManager.LoadScene("scoreScene");
		}
	}

	public void startRound () {
		Shuffle (randomList);
		GameObject roundPanel = Instantiate (GamePanel, Vector3.zero, Quaternion.identity, canvas.transform);
		roundPanel.transform.localPosition = Vector3.zero;
	}
		
	public static void nextPlayer(){
		if (playerNumber == PlayerPrefs.GetInt ("playerNumber")) {
			playerNumber = 1;
		} else {
			playerNumber += 1;
		}
		randomList = roundScript.roundList;
	}

	public static void nextRound(){
		for(int i = 0; i < _wordList.Count; i++){
			randomList.Add (_wordList [i]);
		}
		round += 1;
	}	
		
	public void Shuffle(List<string> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0, n + 1);  
			string value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}
