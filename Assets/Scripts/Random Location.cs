using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour {
	public GameObject LetterBox;
	private GameObject[] LetterBoxes;
	public int DesiredNumberOfBoxes;


	// Use this for initialization
	void Start () 
	{
		int x = 1;
		while(x<= DesiredNumberOfBoxes)
		{
			LetterBoxes = GameObject.FindGameObjectsWithTag ("Fire Letters");
			foreach (GameObject LetterBox in LetterBoxes)
			{
				Vector3 RandomSpawn = new Vector3(Random.Range(0.0f, 500.0f), Random.Range(0.0f, 100.0f), Random.Range(0.0f, 500.0f) );
				Instantiate(LetterBox,RandomSpawn,Quaternion.identity);
			}
		
	}
	}
	


}
