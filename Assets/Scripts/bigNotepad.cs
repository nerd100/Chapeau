using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bigNotepad : MonoBehaviour {

	//public static string playername;
	public InputField playernameInput;
	public InputField inputField1;
	public InputField inputField2;
	public InputField inputField3;
	public string[] words = new string[3];
	public string notepadNumber;

	Dictionary<string, string> dictionary = new Dictionary<string, string>();

	public void show(){
		inputField1.inputType = InputField.InputType.Standard; 
		inputField2.inputType = InputField.InputType.Standard; 
		inputField3.inputType = InputField.InputType.Standard;
		if(inputField1.text != "")
			inputField1.ActivateInputField();
		if(inputField2.text != "")
			inputField2.ActivateInputField();
		if(inputField3.text != "")
			inputField3.ActivateInputField();
	}


	public void closeBigNotepad(){
		if (dictionary.Count == 0) {
			dictionary.Add ("word1", inputField1.text);
			dictionary.Add ("word2", inputField2.text);
			dictionary.Add ("word3", inputField3.text);
		} else {
			dictionary ["word1"] = inputField1.text;
			dictionary ["word2"] = inputField2.text;
			dictionary ["word3"] = inputField3.text;
		}
		for (int i = 0; i < words.Length; i++) {
			words [i] = dictionary ["word" + (i+1)];
		}
		if(inputField1.text != "")
			inputField1.inputType = InputField.InputType.Password; 
		if(inputField2.text != "")
			inputField2.inputType = InputField.InputType.Password; 
		if(inputField3.text != "")
			inputField3.inputType = InputField.InputType.Password;
		
		if (playernameInput.text != "") {
			//playername = playernameInput.text;
		}
		//transform.parent.name = "bigNotepad_"+playername;
		notepadNumber = transform.parent.name.Replace("bigNotepad_Player","");
		wordInputHandler.playerNames [int.Parse (notepadNumber)-1] = playernameInput.text;
		//TODO: neuen Namen in playerNames an richtiger Stelle einfügen
		//Debug.Log (wordInputHandler.playerNames);
		wordInputHandler.updateNotepadName(int.Parse(notepadNumber)-1,playernameInput.text);
		PlayerPrefs.SetString("wordsFromPlayer"+notepadNumber, GetSerializedString(words));
		this.transform.parent.gameObject.SetActive (false);

	}

	private static string GetSerializedString (string[] data)
	{
		if (data.Length == 0) return string.Empty;

		string result = "";
		for (int i = 0; i < data.Length; i++)
		{
			if(i < data.Length-1)
				result += (data[i]+"|");
			else
				result += (data[i]);
		}
		return result;
	}
}
