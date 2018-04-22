using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour {
	public bool IsStanding () {
		return (GetComponent<Transform>().rotation.x >= -79 || GetComponent<Transform>().rotation.x <= -101);
	}
}
