﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {

	public float maxSpeedMagnitude = 30f;
	public float maxAccelerationMagnitude = 3f;
	public float jerkMagnitude = 0.5f;
	public float turnRate = 10f;

	private float speed;
	private float acceleration;
	private float horizontalAxis;
	private bool isInTheWeeds;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = 0f;
		acceleration = 0f;
		horizontalAxis = 0f;

		isInTheWeeds = false;

		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 1, 0), turnRate * horizontalAxis * Time.deltaTime);
	}
	private void FixedUpdate()
	{      
		rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);

		if (rb.velocity.magnitude > maxSpeedMagnitude)
			rb.velocity = rb.velocity.normalized * maxSpeedMagnitude;
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.gameObject.CompareTag("Weeds")){
			isInTheWeeds = true;	
		}
	}
    private void OnCollisionExit(Collision collision)
    {
		if (collision.collider.gameObject.CompareTag("Weeds"))
		{
			isInTheWeeds = false;
		}
    }

	public void Accelerate (bool isPedalDown = false, bool isReverse = false) {

		float jerk = 0;
		float maxAcceleration = maxAccelerationMagnitude;
		float maxSpeed = maxSpeedMagnitude;

		if (isInTheWeeds) {
			maxAcceleration /= 2;
			maxSpeed /= 2;
		}

		if (isPedalDown)
		{
			jerk = jerkMagnitude;
			if (isReverse) jerk *= -1;


			if (acceleration + jerk > maxAcceleration)
				acceleration = maxAcceleration;
			else if (acceleration + jerk < (maxAcceleration * -1))
				acceleration = maxAcceleration * -1;
            else acceleration += jerk;
		}
		else {
			if (speed < 0)
				acceleration = maxAcceleration * 10; // speed up
			else 
				acceleration = maxAcceleration * -1000; // slow down
		}

       
		if (speed + acceleration > maxSpeed)
			speed = maxSpeed;      
        else if (speed + acceleration <= 0 && speed >= 0 && !isPedalDown) {
            speed = 0;
            acceleration = 0;
        }
		else if (speed + acceleration >= 0 && speed <= 0 && !isPedalDown) {
			speed = 0;
			acceleration = 0;
		}
		else if (speed + acceleration < (maxSpeed * -1))
			speed = maxSpeed * -1;
        else speed += acceleration;
  
	}

	public void Turn (float horizontalAxis) {
		this.horizontalAxis = horizontalAxis;
	}

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
