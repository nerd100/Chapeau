using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	Vector3 currPosition = new Vector3(0,0,0);
	Vector3 newPosition = new Vector3(0,0,0);
	bool player1 = true;
	public float speed = 2.0F;
	private float startTime;
	private float journeyLength;


	// Use this for initialization
	void Start () {
		currPosition = this.gameObject.transform.position;
		newPosition = new Vector3 (0.0f, 2.0f, -2.5f);
		Debug.Log ("x: " + currPosition.x.ToString() + ", y: " + currPosition.y.ToString () + ", z: " + currPosition.z.ToString ());
		startTime = Time.time;
		journeyLength = Vector3.Distance(currPosition, newPosition);
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (player1 == true) {
			//float distCovered = (Time.time - startTime) * speed;
			//float fracJourney = distCovered / journeyLength;

			//this.gameObject.transform.position = newPosition;
			//this.gameObject.transform.position = Vector3.Lerp(currPosition, newPosition, fracJourney);
		//}
	}
}
