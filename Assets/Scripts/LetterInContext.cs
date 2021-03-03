using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterInContext : MonoBehaviour {
	public GameObject Letterbox;
	private TextMesh textMesh;
	// Use this for initialization
	void Start () {
		TextMesh text = Letterbox.GetComponent<TextMesh>();
		textMesh = this.GetComponent<TextMesh> ();
		textMesh = text;

		
	}
	


}
