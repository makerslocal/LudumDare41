using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour {

	private const int FALL_ANGLE = 11;
	private GameController gameController;
	private bool HasEverFallen = false;

	private void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(!gameController.isRaceCompleted && collision.transform.gameObject.CompareTag("Player")) {
			gameController.isRaceCompleted = true;
		}
	}

	public bool IsStanding () {
		if (HasEverFallen)
			return false;
		//Debug.Log (GetComponent<Transform> ().eulerAngles.x);
		return ! (GetComponent<Transform>().eulerAngles.x >= 270 + FALL_ANGLE 
		        || GetComponent<Transform>().eulerAngles.x <= 270 - FALL_ANGLE);
	}   

	void Update() {
		if ( ! IsStanding() ) {
			HasEverFallen = true;
		}
	}


}
