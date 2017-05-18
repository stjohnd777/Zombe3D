using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearConstantSpeedMovement : MonoBehaviour {

	public Transform leftLimit;

	public Transform resetPossition;

 	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

        if (GameManager.instance.IsGameOver || !GameManager.instance.IsPlayerActive) {
			return;
		}

		transform.localPosition = new Vector3(transform.localPosition.x +Time.deltaTime*speed, transform.localPosition.y, transform.localPosition.z);

		if ( transform.localPosition.x > leftLimit.localPosition.x){
			transform.localPosition = new Vector3(resetPossition.localPosition.x , transform.localPosition.y, transform.localPosition.z);
		}
	}
}
