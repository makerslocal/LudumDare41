using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private float raceTime;

	public Text timerText;
    
	// Use this for initialization
	void Start () {
		raceTime = 0f;
	}

	// Update is called once per frame
	void Update () {
		raceTime = Time.timeSinceLevelLoad;
		timerText.text = "" + (int)(raceTime / 60f) 
			+ "\'" + (int)(raceTime % 60) 
			+ "\"" + (int)((raceTime * 100) % 100);
	}
}
