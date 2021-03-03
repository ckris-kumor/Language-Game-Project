using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticPath : MonoBehaviour {

	public GameObject explosionDisplay;
	public float initailVelocity = 10.0f;
	public float timeResolution = 0.02f;
	public float maxTime = 10.0f;
	public LayerMask layerMask = -1;

	private GameObject explosionDisplayInstance;

	private LineRenderer lineRend;

	// Use this for initialization
	void Start () {
		lineRend = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 velocityVector = transform.forward * initailVelocity;
		lineRend.SetVertexCount ((int)(maxTime / timeResolution));
		int index = 0;

		Vector3 currentPos = transform.position;

		for (float i = 0.0f; i < maxTime; i += timeResolution) {
			lineRend.SetPosition (index, currentPos);
			RaycastHit hit;
			if (Physics.Raycast (currentPos, velocityVector, out hit, velocityVector.magnitude * timeResolution, layerMask)) {
				lineRend.SetVertexCount (index + 2);
				lineRend.SetPosition (index + 1, hit.point);

				if (explosionDisplay != null) {
					if (explosionDisplayInstance != null) {
						explosionDisplayInstance.SetActive (true);
						explosionDisplayInstance.transform.position = hit.point;
					} else {
				
						explosionDisplayInstance = Instantiate (explosionDisplay, hit.point, Quaternion.identity) as GameObject;
						explosionDisplayInstance.SetActive (true);
				
					}

					break;
				}

			} else {
				if (explosionDisplayInstance != null) {
					explosionDisplayInstance.SetActive (false);
				}

			}
			currentPos += velocityVector * timeResolution;
			velocityVector += Physics.gravity * timeResolution;
			index++;
		}
	}
}
