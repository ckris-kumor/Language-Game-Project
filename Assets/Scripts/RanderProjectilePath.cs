using UnityEngine;
using System.Collections;

public class RanderProjectilePath : MonoBehaviour {
	public GameObject explosionDisplay;
	public float InitialVelocity = 10.0f;
	public float timeResolution = 0.02f;
	public float maxTime = 10.0f;
	public LayerMask layermask = -1;
	public Vector3 lineRendererPosition;
	private string ToggleProjectilepath = "Fire3";
	RaycastHit hit;

	private LineRenderer lineRenderer;
	GameObject explosionDisplayInstance;
	public GameObject StartPositionForLinRenderer;



	// Use this for initialization
	void Start ()
	{
		lineRenderer = GetComponent<LineRenderer> ();
		explosionDisplayInstance = Instantiate (explosionDisplay, hit.point, Quaternion.identity) as GameObject;
		explosionDisplayInstance.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () 
	{
		Vector3 velocityVector = transform.forward * InitialVelocity;

		lineRenderer.SetVertexCount ((int)(maxTime / timeResolution));

		int index = 0;

		Vector3 currentPosition = StartPositionForLinRenderer.transform.position;




		for (float t = 0.0f; t < maxTime; t += timeResolution) 
		{
			
			lineRenderer.SetPosition (index, currentPosition + lineRendererPosition);

			if (Physics.Raycast (currentPosition + lineRendererPosition, velocityVector, out hit, velocityVector.magnitude*timeResolution, layermask)) {
				lineRenderer.SetVertexCount (index + 2);
				lineRenderer.SetPosition (index + 1, hit.point);
				if (explosionDisplay != null) {
					
					if (explosionDisplayInstance != null) {
						//explosionDisplayInstance.SetActive (true);
						explosionDisplayInstance.transform.position = hit.point;
					} 
					/*
					else {
						explosionDisplayInstance = Instantiate (explosionDisplay, hit.point, Quaternion.identity) as GameObject;
					}
					*/
				}
				break;
			}
			/*	else {
				if (explosionDisplayInstance != null) {
					explosionDisplayInstance.SetActive (false);
				} 
			}
			*/
			currentPosition += velocityVector * timeResolution;
			velocityVector += Physics.gravity* timeResolution;
			index++;
		}

		if (Input.GetButtonDown (ToggleProjectilepath)) {
			if (explosionDisplayInstance.activeInHierarchy == true && lineRenderer.enabled == true) {
				explosionDisplayInstance.SetActive (false);
				lineRenderer.enabled = false;
				explosionDisplay.SetActive (false);

			} 
			else {
				explosionDisplayInstance.SetActive (true);
				lineRenderer.enabled = true;
				explosionDisplay.SetActive (true);

			}
		}
				
	}
}
