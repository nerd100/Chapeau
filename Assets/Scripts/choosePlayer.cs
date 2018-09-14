using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class choosePlayer : MonoBehaviour {

	public GameObject playerText;
	public GameObject timeText;
	int MAXPLAYER = 6;
	int MINPLAYER = 3;
	int MAXTIME = 60;
	int MINTIME = 30;
	int _player { get; set; }
	int _time { get; set; }

	string wordInput = "wordInput";

	public int get_player()
	{
		return this._player;
	}

	public void set_player(int player)
	{
		this._player = player;
	}
	public int get_time()
	{
		return this._time;
	}
	public void set_time(int time)
	{
		_time = time;
	}

	void Start(){
		set_player(int.Parse(playerText.GetComponentInChildren<Text> ().text));
		set_time(int.Parse(timeText.GetComponentInChildren<Text> ().text));
	}

	public void incPlayer(){
		if (get_player() < MAXPLAYER) {
			set_player(get_player() + 1);
			playerText.GetComponentInChildren<Text> ().text = get_player ().ToString ();

		}	
	}
	public void decPlayer(){
		if (get_player() > MINPLAYER) {
			set_player(get_player() - 1);
			playerText.GetComponentInChildren<Text> ().text = get_player ().ToString ();
		}
	}
	public void incTime(){
		if (get_time() < MAXTIME) {
			set_time(get_time() + 10);
			timeText.GetComponentInChildren<Text> ().text = get_time ().ToString ();
		}
	}
	public void decTime(){
		if (get_time() > MINTIME) {
			set_time(get_time() - 10);
			timeText.GetComponentInChildren<Text> ().text = get_time ().ToString ();
			/*while (get_time() > 1) {
				set_time (get_time() - 1);
				StartCoroutine(Wait());
				timeText.GetComponentInChildren<Text> ().text = get_time ().ToString ();
			}*/
		}
	}

	public void nextScene(){
		PlayerPrefs.SetInt("playerNumber", _player);
		PlayerPrefs.SetInt("time",_time);
		SceneManager.LoadScene(wordInput);
	}
	public void backToMenu(){
		SceneManager.LoadScene("menu");
	}
	/*
	IEnumerator Wait()
	{
		set_time (get_time() - 1);
		StartCoroutine(Wait());
		timeText.GetComponentInChildren<Text> ().text = get_time ().ToString ();
		yield return new WaitForSeconds(1);

	}
	*/	

}
