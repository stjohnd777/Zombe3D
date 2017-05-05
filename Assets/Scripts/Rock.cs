using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public bool useLocal = true;

	public Transform[] waypoints;

	public bool isWaitBetweenWaypoints;

	public float waitTimeBetweenWaypoint = .5f;

	public bool isRepeating = true;

	public float speed = 1f;

	public float threshhold = .1f;

	void Start () {
		StartCoroutine ( Move(waypoints[0]) ); 
	}

	int currentWaypointIndex = 0;

	IEnumerator Move( Transform currentWaypoint){

		float dist = 0;

		if ( useLocal) {
		  dist =  Vector3.Distance(transform.position, currentWaypoint.position);
		}else {
		 dist =  Vector3.Distance(transform.localPosition, currentWaypoint.localPosition);
		}
 

		while ( dist > threshhold)
		{
			float step = speed * Time.deltaTime;

			if ( useLocal) {
				transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);
			}else {
				transform.position = Vector3.MoveTowards(transform.localPosition, currentWaypoint.localPosition, step);
			}
		 

			if ( useLocal) {
				dist =  Vector3.Distance(transform.position, currentWaypoint.position);
			}else {
				dist =  Vector3.Distance(transform.localPosition, currentWaypoint.localPosition);
			}

			yield return null;
		}

		yield return new WaitForSeconds (waitTimeBetweenWaypoint);

		currentWaypointIndex++;

		if ( currentWaypointIndex < waypoints.Length ){
			StartCoroutine (Move(waypoints[currentWaypointIndex]));
		} else {

			if ( isRepeating ){
				currentWaypointIndex = 0;
				StartCoroutine (Move(waypoints[currentWaypointIndex]));
			}

		}

	}
}
