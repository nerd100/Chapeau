using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonWarningScript : MonoBehaviour {

	public void closePanel(){
		Destroy (transform.parent.gameObject);
	}
}
