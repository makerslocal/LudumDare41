using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour {

	public float minimumBounceMagnitude;
	public float minimumBounceCorrectionMultiplier;

	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody bouncee = collision.gameObject.GetComponent<Rigidbody>();
		Vector3 bouncedVelocity = Vector3.zero;
		if (collision.gameObject.transform.parent.CompareTag("Player"))
		{
			bouncedVelocity = collision.gameObject.GetComponent<CarBehavior>().velocity;
		}
		else if (collision.gameObject.CompareTag("Ball")){
			bouncedVelocity = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>().velocity;
		}
		Vector3 contactPoint = collision.contacts[0].normal;
		if(bouncedVelocity != Vector3.zero){

			if (contactPoint.x > 0.1f || contactPoint.x < -0.1f)
			{
				bouncedVelocity = new Vector3(
					bouncedVelocity.x * -1,
					bouncedVelocity.y,
					bouncedVelocity.z
				);

				if(bouncedVelocity.magnitude < minimumBounceMagnitude) {
					bouncedVelocity = new Vector3(
						bouncedVelocity.x * minimumBounceCorrectionMultiplier,
                        bouncedVelocity.y,
                        bouncedVelocity.z                  
					);
				}
			}
			if (contactPoint.z > 0.1f || contactPoint.z < -0.1f)
			{
				bouncedVelocity = new Vector3(
					bouncedVelocity.x,
					bouncedVelocity.y,
					bouncedVelocity.z * -1
				);

				if (bouncedVelocity.magnitude < minimumBounceMagnitude)
                {
                    bouncedVelocity = new Vector3(
                        bouncedVelocity.x,
						bouncedVelocity.y * minimumBounceCorrectionMultiplier,
                        bouncedVelocity.z
                    );
                }
			}

			bouncee.AddForceAtPosition(
				force: bouncedVelocity,
				position: contactPoint,
				mode: ForceMode.Impulse
			);
		}
	}
 
}
