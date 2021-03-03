using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWand : MonoBehaviour {
	GameObject [] GreenCubes;
	private Mesh newWand;
	private static Mesh original;
	private Mesh constanOrginal;
	GameObject player;
	public GameObject wand;
	public GameObject wand2;
	public GameObject wand3;
	public GameObject wand4;
	public float distance;
	GameObject Green_Wand_Power;


	void Start (){
		constanOrginal = gameObject.GetComponent<MeshFilter> ().mesh;
		Green_Wand_Power = GameObject.FindGameObjectWithTag ("Green Particles");
		Green_Wand_Power.GetComponent<ParticleSystem> ().Stop ();
		GreenCubes = GameObject.FindGameObjectsWithTag ("Green Rune Cube");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GlobalVar.Check.ToString ());


		if (Input.GetButtonDown ("Button2")) {

			newWand = wand.GetComponent<MeshFilter> ().sharedMesh;

			original = gameObject.GetComponent<MeshFilter> ().mesh = newWand;
			Green_Wand_Power.GetComponent<ParticleSystem> ().Stop ();
			GlobalVar.Check = 1;

		} else if (Input.GetButtonDown ("Button3")) {
			newWand = wand2.GetComponent<MeshFilter> ().sharedMesh;

			original = gameObject.GetComponent<MeshFilter> ().mesh = newWand;
			Green_Wand_Power.GetComponent<ParticleSystem> ().Stop ();
			GlobalVar.Check = 2;

		} else if (Input.GetButtonDown("Button1")) {
			Green_Wand_Power.GetComponent<ParticleSystem> ().Stop ();

			original = gameObject.GetComponent<MeshFilter> ().mesh = constanOrginal;

			GlobalVar.Check = 0;
		}
		else if (Input.GetButtonDown("Button4")) {

			newWand = wand3.GetComponent<MeshFilter> ().sharedMesh;
			original = gameObject.GetComponent<MeshFilter> ().mesh = newWand;
			Green_Wand_Power.GetComponent<ParticleSystem> ().Play ();
			GlobalVar.Check = 3;
			if (GlobalVar.SunsColor == Color.black) {
				float Distance;
				foreach (GameObject GreenCube in GreenCubes) {
					Distance = Vector3.Distance (GreenCube.transform.position, player.transform.position);
					if (Distance <= distance) {
						Green_Wand_Power.GetComponent<ParticleSystem> ().transform.rotation = Quaternion.Euler(player.transform.position);
					}
				}
//
				
			}
		}
		else if (Input.GetButtonDown("Button5")) {
			Green_Wand_Power.GetComponent<ParticleSystem> ().Stop ();
			newWand = wand4.GetComponent<MeshFilter> ().sharedMesh;
			original = gameObject.GetComponent<MeshFilter> ().mesh = newWand;

			//
			GlobalVar.Check = 4;
		}
		
	}
}
