using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {

	public float maxSpeedMagnitude = 30f;
	public float maxAccelerationMagnitude = 3f;
	public float jerkMagnitude = 0.5f;

	private float speed;
	private float acceleration;

	// Use this for initialization
	void Start () {
		speed = 0f;
		acceleration = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
	}

	public void Accelerate (bool isReverse = false) {

		float jerk = jerkMagnitude;
		if (isReverse) jerk *= -1;

        if (acceleration + jerk > maxAccelerationMagnitude)
            acceleration = maxAccelerationMagnitude;
		else if (acceleration + jerk < (maxAccelerationMagnitude * -1))
			acceleration = maxAccelerationMagnitude * -1;
        else acceleration += jerk;

		if (speed + acceleration > maxSpeedMagnitude)
			speed = maxSpeedMagnitude;
		else if (speed + acceleration < (maxSpeedMagnitude * -1))
			speed = maxSpeedMagnitude * -1;
		else speed += acceleration;

	}
}
