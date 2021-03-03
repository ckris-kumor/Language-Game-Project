using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastForward : MonoBehaviour {
	public static RaycastHit hit;
	
	// Update is called once per frame
	void Update () {

		float theDistance;

		//Debug Raycast
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		Debug.DrawRay (transform.position,forward,Color.green);

		if(Physics.Raycast(transform.position,forward, out hit)){
			theDistance = hit.distance;
			//print (theDistance + " " + hit.collider.gameObject.name);
		}
	}
}
