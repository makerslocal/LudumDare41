using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject MapFragment;
	public GameObject PinSetup;
	public GameObject Bumper;
	public GameObject Ball;

	double[] segmentOffsets = {
		0.0,
		0.0,
		0.0,
		0.0,
		0.0,
		0.0,
		0.0,
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
		-13.02361332501978,
		0.0,
		17.364817766693033,
		34.20201433256687,
		49.99999999999999,
		64.27876096865393,
		76.60444431189781,
		86.60254037844386,
		93.96926207859083,
		98.4807753012208,
		100.0,
		98.4807753012208,
		93.96926207859084,
		86.60254037844388,
		76.60444431189781,
		64.27876096865394,
		49.99999999999999,
		34.20201433256689,
		17.364817766693026,
		1.2246467991473532e-14,
		-17.364817766693047,
		-34.20201433256687,
		-50.000000000000014,
		-64.27876096865393,
		-76.6044443118978,
		-86.60254037844383,
		-93.96926207859084,
		-98.4807753012208,
		-100.0,
		-98.48077530122082,
		-93.96926207859083,
		-86.60254037844386,
		-76.60444431189781,
		-64.27876096865396,
		-50.00000000000004,
		-34.20201433256686,
		-17.36481776669304,
		0.0,
		25.651510749425153,
		48.209070726490445,
		64.9519052838329,
		73.8605814759156,
		73.8605814759156,
		64.9519052838329,
		48.20907072649046,
		25.651510749425167,
		9.184850993605149e-15,
		-25.65151074942515,
		-48.209070726490445,
		-64.95190528383287,
		-73.8605814759156,
		-73.86058147591561,
		-64.9519052838329,
		-48.20907072649047,
		-25.651510749425146,13.023613325019776,
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
		//So where is the center of the lane?
		float laneX = (float) (segmentOffsets [segmentOffsets.Length - 1]);

		//Add the ball
		GameObject ball = Instantiate(Ball, new Vector3(laneX, 6, nextZPos), Quaternion.identity);
		ball.GetComponent<Transform> ().parent = GameObject.Find ("Units").GetComponent<Transform> ();
			
		//Add the lane floor
		for (int i = 0; i < 15; i++) {
			GameObject fragment = Instantiate (MapFragment, new Vector3 (laneX, 0, nextZPos), Quaternion.identity);
			fragment.GetComponent<Transform> ().parent = GameObject.Find ("Structure").GetComponent<Transform> ();

			Vector3 fragmentPos = fragment.GetComponent<Transform> ().position;
			float bumperOffset = fragment.GetComponent<MapFragmentBehavior> ().roadWidth / 2;
			float fragmentDepth = fragment.GetComponent<MapFragmentBehavior> ().segmentDepth;

			GameObject leftBumper = Instantiate (
				Bumper,
				new Vector3 (fragmentPos.x - bumperOffset, fragmentPos.y + 15, nextZPos),
				Quaternion.identity
			);
			leftBumper.GetComponent<Transform> ().localScale = new Vector3 (2, 30, fragmentDepth);
			leftBumper.GetComponent<Transform> ().parent = fragment.GetComponent<Transform>();

			GameObject rightBumper = Instantiate (
				Bumper,
				new Vector3 (fragmentPos.x + bumperOffset, fragmentPos.y + 15, nextZPos),
				Quaternion.identity
			);
			rightBumper.GetComponent<Transform> ().localScale = new Vector3 (2, 30, fragmentDepth); //XXX hardcoding of bumper sizing
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
