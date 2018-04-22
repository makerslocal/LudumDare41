using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject MapFragment;
	public GameObject PinSetup;
	public GameObject Bumper;

	double[] segmentOffsets = {
		0.0,
		13.023613325019776,
		25.651510749425153,
		37.49999999999999,
		48.209070726490445,
		57.45333323392335,
		64.9519052838329,
		70.47694655894313,
		73.8605814759156,
		75.0,
		73.8605814759156,
		70.47694655894313,
		64.9519052838329,
		57.45333323392335,
		48.20907072649046,
		37.49999999999999,
		25.651510749425167,
		13.02361332501977,
		9.184850993605149e-15,
		-13.023613325019785,
		-25.65151074942515,
		-37.50000000000001,
		-48.209070726490445,
		-57.453333233923345,
		-64.95190528383287,
		-70.47694655894313,
		-73.8605814759156,
		-75.0,
		-73.86058147591561,
		-70.47694655894313,
		-64.9519052838329,
		-57.45333323392336,
		-48.20907072649047,
		-37.500000000000036,
		-25.651510749425146,
		-13.02361332501978
	};

	// Use this for initialization
	void Start () {      

		float nextZPos = 0;

		//Load in the actual road pattern from the array
		foreach (float offset in segmentOffsets) {
			GameObject fragment = Instantiate (MapFragment, new Vector3 (offset, 0, nextZPos), Quaternion.identity);
			fragment.GetComponent<Transform> ().parent = GameObject.Find("Structure").GetComponent<Transform>();
			nextZPos += fragment.GetComponent<MapFragmentBehavior> ().segmentDepth;
		}

		//Generate our bowling lane, which is just a straight runway riffing off the end segment position
		float laneX = (float) (segmentOffsets [segmentOffsets.Length - 1]);
		for (int i = 0; i < 15; i++) {
			GameObject fragment = Instantiate (MapFragment, new Vector3 (laneX, 0, nextZPos), Quaternion.identity);
			fragment.GetComponent<Transform> ().parent = GameObject.Find ("Structure").GetComponent<Transform> ();

			Vector3 fragmentPos = fragment.GetComponent<Transform> ().position;
			float bumperOffset = fragment.GetComponent<MapFragmentBehavior> ().roadWidth / 2;
			float fragmentDepth = fragment.GetComponent<MapFragmentBehavior> ().segmentDepth;

			GameObject leftBumper = Instantiate (
				Bumper,
				new Vector3 (fragmentPos.x - bumperOffset, fragmentPos.y + 1, nextZPos),
				Quaternion.identity
			);
			leftBumper.GetComponent<Transform> ().localScale = new Vector3 (2, 10, fragmentDepth);
			leftBumper.GetComponent<Transform> ().parent = fragment.GetComponent<Transform>();

			GameObject rightBumper = Instantiate (
				Bumper,
				new Vector3 (fragmentPos.x + bumperOffset, fragmentPos.y + 1, nextZPos),
				Quaternion.identity
			);
			rightBumper.GetComponent<Transform> ().localScale = new Vector3 (2, 10, fragmentDepth); //XXX hardcoding of bumper sizing
			rightBumper.GetComponent<Transform> ().parent = fragment.GetComponent<Transform>();

			nextZPos += fragmentDepth;
		}

		//Finally place the pins
		GameObject pins = Instantiate (PinSetup, new Vector3 ((float)(segmentOffsets [segmentOffsets.Length - 1]), (float)9.60, nextZPos-50), Quaternion.identity); //XXX hokey hardcoding
		pins.GetComponent<Transform> ().parent = GameObject.Find ("Units").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
