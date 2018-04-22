using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehavior : MonoBehaviour {

	private Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GetComponent<Transform>().parent;
		offset = GetComponent<Transform>().position - player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//GetComponent<Transform>().position = player.position + offset;
	}
}
