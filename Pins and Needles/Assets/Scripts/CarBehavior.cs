using System.Collections;
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

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = 0f;
		acceleration = 0f;
		horizontalAxis = 0f;

		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 1, 0), turnRate * horizontalAxis * Time.deltaTime);
	}
	private void FixedUpdate()
	{      
		rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
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
				acceleration = maxAccelerationMagnitude * 10; // speed up
			else 
				acceleration = maxAccelerationMagnitude * -1000; // slow down
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

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
