using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGreenCube : MonoBehaviour {
	GameObject  GreenRuneCubeAreaCollider;
	GameObject GreenRuneCube;
	GameObject GreenRune;
	Light[]  GreenRuneLights;
	GameObject Player;




	void HGC()
	{
		//GreenRuneCubeAreaCollider.GetComponent<BoxCollider> ().enabled = true;
		GreenRuneCube.GetComponent<MeshRenderer> ().enabled = false;
		GreenRuneCube.GetComponent<BoxCollider> ().enabled = false;
		GreenRune.GetComponent<MeshRenderer> ().enabled = false;

		foreach (Light GreenRuneLight in GreenRuneLights) {
			GreenRuneLight.enabled = false;
		}

	}
	void SGC()
	{
		GreenRuneCubeAreaCollider.GetComponent<BoxCollider> ().enabled = true;
		GreenRuneCube.GetComponent<MeshRenderer> ().enabled = true;
		GreenRune.GetComponent<MeshRenderer> ().enabled = true;
		foreach (Light GreenRuneLight in GreenRuneLights) {
			GreenRuneLight.enabled = true;
		}

	}

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		GreenRuneCubeAreaCollider = GameObject.FindGameObjectWithTag ("GreenCubeAreaCollider");
		GreenRune = GameObject.FindGameObjectWithTag ("GreenRune");
		GreenRuneLights = GreenRune.GetComponentsInChildren<Light>();
		GreenRuneCube = GameObject.FindGameObjectWithTag ("Green Rune Cube");
		HGC ();
		//Physics.IgnoreCollision (GreenRuneCubeAreaCollider.GetComponent<Collider> (), Player.GetComponent<Collider> ());
	}
	
	void OnCollisionEnter(Collision other)
	{
//		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Green Wand Power") 
		{
			//Physics.IgnoreCollision (other.gameObject.GetComponent<Collider>(), Player.GetComponent<Collider> ());
			Debug.Log ("You are in the OnCollisionEnter Function");
			Debug.Log (GreenRuneCubeAreaCollider.GetComponent<BoxCollider> ().tag);
			Debug.Log (Player.tag);
			Physics.IgnoreCollision ((GreenRuneCubeAreaCollider.GetComponent<Collider> ()), Player.GetComponent<Collider> ());
			if (GreenRuneCubeAreaCollider.GetComponent<BoxCollider> ().bounds.Contains (Player.transform.position) && !(GreenRuneCube.GetComponent<MeshRenderer> ().enabled)) 
				{
					Debug.Log ("You should see the GreenRuneCube");
					SGC ();
				} 

		}


	}
}
