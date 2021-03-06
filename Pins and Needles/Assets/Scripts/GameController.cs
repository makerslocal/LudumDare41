﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private float raceTime;
	private float postraceTime;

	[HideInInspector]
	public bool isRaceCompleted;

	public float timeAfterGame;
	public Text timerText;
	public Text scoreText;
	public GameObject InputField;
	public float Score;
    
	// Use this for initialization
	void Start () {
		raceTime = 0f;
		postraceTime = 0f;
		isRaceCompleted = false;

		Time.timeScale = 2f;
	}

	string TimeToText(float time2) {
		return "" + ((int)(time2 / 60f)).ToString().PadLeft(2, '0')
			+ "\'" + ((int)(time2 % 60)).ToString().PadLeft(2, '0')
			+ "\"" + ((int)((time2 * 100) % 100)).ToString().PadLeft(2, '0');
	}
	float ScaleTime(float time) {
		return time / Time.timeScale;
	}

	// Update is called once per frame
	void Update () {
		if (!isRaceCompleted)
		{
			raceTime = Time.timeSinceLevelLoad;
			timerText.text = TimeToText (ScaleTime ((raceTime)));

		}
		else {
			postraceTime = Time.timeSinceLevelLoad - raceTime;
			if (postraceTime > timeAfterGame) {
				GetScore();
			}
		}

		if (Input.GetKeyUp(KeyCode.Escape)) {
			SceneManager.LoadScene(0);
		}
	}

	int GetPinsDown () {
		int pinsDown = 0;
		foreach(GameObject pin in GameObject.FindGameObjectsWithTag("Pin"))
			if (! pin.GetComponent<PinBehavior>().IsStanding())
				pinsDown++;

		return pinsDown;
	}

	float GetScore() {
					return Mathf.Max(ScaleTime(raceTime) - GetPinsDown(), 0);
	}

	public IEnumerator EndGame() {

		if (isRaceCompleted)
			yield break; //for debug purposes.

		GameObject.Find("RollSound").GetComponent<AudioSource>().Play();

		//GameObject.Find ("Car").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GameObject.Find ("Car").GetComponent<CarBehavior>().Accelerate(false, false);
		GameObject.Find ("Car").GetComponent<CarBehavior> ().Turn (0f);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = false;

		isRaceCompleted = true;

		Debug.Log ("The end game stuff will be shown");

		yield return new WaitForSecondsRealtime (timeAfterGame);

		scoreText.text = "Your time: " + TimeToText(ScaleTime( (raceTime))) + "\n" +
						"Bonus Time for " + GetPinsDown () + " pins down: " + TimeToText(((float)GetPinsDown ())) + "\n" +
						"FINAL SCORE: " + TimeToText((GetScore ())) + "\n" +
			            "Press <Esc> to restart";

		Score = GetScore (); //for the leaderboard
		

		scoreText.enabled = true;
		InputField.SetActive (true);
		Time.timeScale = 0f;

		//yield return new WaitForSecondsRealtime (5f);
		//SceneManager.LoadScene ("prototype-001");

	}
}
