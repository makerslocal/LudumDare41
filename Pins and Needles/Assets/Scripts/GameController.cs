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
	}

	// Update is called once per frame
	void Update () {
		if (!isRaceCompleted)
		{
			raceTime = Time.timeSinceLevelLoad;
			timerText.text = "" + (int)(raceTime / 60f)
				+ "\'" + (int)(raceTime % 60)
				+ "\"" + (int)((raceTime * 100) % 100);
		}
		else {
			postraceTime = Time.timeSinceLevelLoad - raceTime;
			if (postraceTime > timeAfterGame) {
				Score();
			}
		}
	}

	void Score () {
		
	}
}
