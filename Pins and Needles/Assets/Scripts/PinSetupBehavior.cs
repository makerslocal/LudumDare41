using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetupBehavior : MonoBehaviour {

	private bool hasBeenHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasBeenHit)
			return;
		foreach (PinBehavior pinB in this.GetComponentsInChildren<PinBehavior>()) {
			if (!pinB.IsStanding () && !hasBeenHit) {
				hasBeenHit = true;
				GameObject.Find ("StrikeSound").GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
