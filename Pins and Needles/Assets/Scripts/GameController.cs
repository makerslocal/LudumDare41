using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private float raceTime;
	private float postraceTime;

	[HideInInspector]
	public bool isRaceCompleted;

	public float timeAfterGame = 3f;
	public Text timerText;
	public Text scoreText;
    
	// Use this for initialization
	void Start () {
		raceTime = 0f;
		postraceTime = 0f;
		isRaceCompleted = false;

		Time.timeScale = 1.75f;
	}

	string timeToScaledTimerText(float time) {
		float time2 = time / Time.timeScale;
		return "" + ((int)(time2 / 60f)).ToString().PadLeft(2, '0')
			+ "\'" + ((int)(time2 % 60)).ToString().PadLeft(2, '0')
			+ "\"" + ((int)((time2 * 100) % 100)).ToString().PadLeft(2, '0');
	}

	// Update is called once per frame
	void Update () {
		if (!isRaceCompleted)
		{
			raceTime = Time.timeSinceLevelLoad;
			timerText.text = timeToScaledTimerText(raceTime);

		}
		else {
			postraceTime = Time.timeSinceLevelLoad - raceTime;
			if (postraceTime > timeAfterGame) {
				GetScore();
			}
		}
	}

	float GetScore () {
		int pinsDown = 0;
		foreach(GameObject pin in GameObject.FindGameObjectsWithTag("Pin"))
			if (pin.GetComponent<PinBehavior>().IsStanding())
				pinsDown++;

		return Mathf.Max(raceTime - pinsDown, 0);
	}

	public void showEndGameStuff() {

		scoreText.enabled = true;

	}
}
