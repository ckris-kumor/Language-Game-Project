using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	public Material color0;
	public Material color1;
	public Material color2;
	public Material[] materials;
	public Renderer rend;

	void Start(){
		rend = GetComponent<Renderer> ();
		rend.enabled = true;

	}

	// Update is called once per frame
	void Update () {

		if (raycastForward.hit.collider == null) {
			rend.material = color1;			
		}

		else if (raycastForward.hit.collider.gameObject) {
			rend.material = color2;
		}


	}
}
