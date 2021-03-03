using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SunColorSpawn : MonoBehaviour {

	GameObject Light;
	GameObject WordDescription;
	void Start () {
		Light = GameObject.FindGameObjectWithTag ("Light");
		WordDescription = GameObject.FindGameObjectWithTag("WordDescription");
		Debug.Log (GlobalVar.SunsColor.ToString ());
		if (GlobalVar.SunsColor != Color.clear && GlobalVar.SunsColor != Color.yellow) {
			Light.GetComponent<Light> ().color = GlobalVar.SunsColor;
			WordDescription.GetComponent<Text>().color = Color.white; 
		} 
		else {
			Light.GetComponent<Light> ().color = Color.yellow;
			WordDescription.GetComponent<Text>().color = Color.black; 
		}

		
	}
	

}
