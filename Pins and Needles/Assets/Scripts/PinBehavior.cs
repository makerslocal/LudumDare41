using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour {

	private GameController gameController;

	private void Start()
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
		return (GetComponent<Transform>().rotation.x >= -79 || GetComponent<Transform>().rotation.x <= -101);
	}   
}
