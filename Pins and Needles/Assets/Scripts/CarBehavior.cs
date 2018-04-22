using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {

	public float maxSpeedMagnitude = 30f;
	public float maxAccelerationMagnitude = 3f;
	public float jerkMagnitude = 0.5f;
	public float turnRate = 10;

	private float speed;
	private float acceleration;
	private float horizontalAxis;

	// Use this for initialization
	void Start () {
		speed = 0f;
		acceleration = 0f;
		horizontalAxis = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
		GetComponent<Transform>().Rotate(new Vector3(0, 1, 0), turnRate * horizontalAxis * Time.deltaTime);
	}

	public void Accelerate (bool isPedalDown = false, bool isReverse = false) {

		float jerk = 0;
		if (isPedalDown)
		{
			jerk = jerkMagnitude;
			if (isReverse) jerk *= -1;


            if (acceleration + jerk > maxAccelerationMagnitude)
                    acceleration = maxAccelerationMagnitude;
                else if (acceleration + jerk < (maxAccelerationMagnitude * -1))
                    acceleration = maxAccelerationMagnitude * -1;
                else acceleration += jerk;
		}
		else {
			if (speed < 0)
				acceleration = maxAccelerationMagnitude * 0.5f; // speed up slowly
			else 
				acceleration = maxAccelerationMagnitude * -1 * 0.5f; // slow down slowly
		}

       
        if (speed + acceleration > maxSpeedMagnitude)
            speed = maxSpeedMagnitude;      
        else if (speed + acceleration <= 0 && speed >= 0 && !isPedalDown) {
            speed = 0;
            acceleration = 0;
        }
		else if (speed + acceleration >= 0 && speed <= 0 && !isPedalDown) {
			speed = 0;
			acceleration = 0;
		}
        else if (speed + acceleration < (maxSpeedMagnitude * -1))
            speed = maxSpeedMagnitude * -1;
        else speed += acceleration;
  
	}

	public void Turn (float horizontalAxis) {
		this.horizontalAxis = horizontalAxis;
	}
}
