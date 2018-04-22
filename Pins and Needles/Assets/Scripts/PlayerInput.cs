using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public CarBehavior car;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Make this actually input-dependent
		car.Accelerate(
			isPedalDown: Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("s") || Input.GetKey("down"),
			isReverse: Input.GetKey("s") || Input.GetKey("down")
		);
		car.Turn(Input.GetAxis("Horizontal"));      
	}
}
