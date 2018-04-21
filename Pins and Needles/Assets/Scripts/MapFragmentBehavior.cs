using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFragmentBehavior : MonoBehaviour {

	public GameObject leftWeeds;
	public GameObject rightWeeds;
	public GameObject road;

	public float weedWidth = 10;
	public float roadWidth = 10;
	public float segmentDepth = 3;

	// Use this for initialization
	void Start () {
		SetScale();
		SetPosition();
	}

	void SetScale() {
       
        Vector3 weedScale = leftWeeds.GetComponent<Transform>().localScale;
        Vector3 roadScale = road.GetComponent<Transform>().localScale;

        weedScale.Set(weedWidth, 1, segmentDepth);
        roadScale.Set(roadWidth, 1, segmentDepth);

        leftWeeds.GetComponent<Transform>().localScale = weedScale;
        rightWeeds.GetComponent<Transform>().localScale = weedScale;
        road.GetComponent<Transform>().localScale = roadScale;

	}

	void SetPosition () {

		Vector3 leftWeedPosition = leftWeeds.GetComponent<Transform>().localPosition;
		Vector3 rightWeedPosition = rightWeeds.GetComponent<Transform>().localPosition;
        
		leftWeedPosition.Set(GetWeedOffsetMagnitude() * -1, 0, 0);
		rightWeedPosition.Set(GetWeedOffsetMagnitude(), 0, 0);

		leftWeeds.GetComponent<Transform>().localPosition = leftWeedPosition;
        rightWeeds.GetComponent<Transform>().localPosition = rightWeedPosition;
	}

    /// <summary>
    /// Gets the weed offset magnitude.
    /// </summary>
    /// <returns>The weed offset magnitude.</returns>
	private float GetWeedOffsetMagnitude () {
		return (weedWidth / 2) + (roadWidth / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
