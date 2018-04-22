using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedometerNeedleBehavior : MonoBehaviour {

	public GameObject Car;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 butt = Car.GetComponent<Rigidbody> ().velocity;
		float speed = Mathf.Abs (butt.x) + Mathf.Abs (butt.z); //Mathf.Abs (butt.y) + 
		//Debug.Log (speed);

		speed -= 10; //The 0mph mark is a little left of 0 degrees
		if ( speed > 265 ) speed = 265;
		this.GetComponent<Transform> ().eulerAngles = new Vector3(0,0, -speed);
	}
}
