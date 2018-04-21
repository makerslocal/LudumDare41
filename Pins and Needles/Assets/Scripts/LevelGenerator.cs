using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject MapFragment;

	// Use this for initialization
	void Start () {      
		
		//TODO: Loop through to create the level.
		GameObject fragment = Instantiate(
			MapFragment,
            new Vector3(0, 0, 0),
            Quaternion.identity
		);
		fragment.GetComponent<Transform>().parent = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
