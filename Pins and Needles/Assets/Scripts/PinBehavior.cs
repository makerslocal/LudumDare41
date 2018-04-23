using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour {

	private const int FALL_ANGLE = 11;
	private GameController gameController;

	private void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	public bool IsStanding () {
		//Debug.Log (GetComponent<Transform> ().eulerAngles.x);
		return ! (GetComponent<Transform>().eulerAngles.x >= 270 + FALL_ANGLE 
		        || GetComponent<Transform>().eulerAngles.x <= 270 - FALL_ANGLE);
	}   


}
