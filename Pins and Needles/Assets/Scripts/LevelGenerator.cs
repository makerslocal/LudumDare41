using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject MapFragment;
	public GameObject PinSetup;

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

		foreach (float offset in segmentOffsets) {
			GameObject fragment = Instantiate (MapFragment, new Vector3 (offset, 0, nextZPos), Quaternion.identity);
			fragment.GetComponent<Transform> ().parent = GameObject.Find("Structure").GetComponent<Transform>();
			nextZPos += fragment.GetComponent<MapFragmentBehavior> ().segmentDepth;
		}
		for (int i = 0; i < 15; i++) {
			GameObject fragment = Instantiate (MapFragment, new Vector3 ((float) (segmentOffsets [segmentOffsets.Length - 1]), 0, nextZPos), Quaternion.identity);
			fragment.GetComponent<Transform> ().parent = GameObject.Find ("Structure").GetComponent<Transform> ();
			nextZPos += fragment.GetComponent<MapFragmentBehavior> ().segmentDepth;
		}

		GameObject pins = Instantiate (PinSetup, new Vector3 ((float)(segmentOffsets [segmentOffsets.Length - 1]), (float)9.60, nextZPos-50), Quaternion.identity); //XXX hokey hardcoding
		pins.GetComponent<Transform> ().parent = GameObject.Find ("Units").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
