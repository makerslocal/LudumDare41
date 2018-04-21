using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private float raceTime;
    
	// Use this for initialization
	void Start () {
		raceTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		raceTime = Time.timeSinceLevelLoad - 3f;
	}
}
