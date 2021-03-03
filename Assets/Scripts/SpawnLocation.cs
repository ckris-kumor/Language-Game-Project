using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour {
	public int NumofBoxesatOnce;
	public GameObject FireBox;
	public GameObject[] FireBoxes;
	public GameObject[] IceBoxes;
	public GameObject[] GreenBoxes;
	public GameObject[] PurpleBoxes;
	public GameObject IceBox;
	public GameObject PurpleBox;
	public GameObject GreenBox;
	public Terrain Map;

	private int x =1;


	// Use this for initialization
	void Start ()
	{
		FireBoxes = GameObject.FindGameObjectsWithTag ("Fire Letters");
		IceBoxes = GameObject.FindGameObjectsWithTag ("Ice Letters");
		GreenBoxes = GameObject.FindGameObjectsWithTag ("Green Rune Cube");
		PurpleBoxes = GameObject.FindGameObjectsWithTag ("Purple Rune Cube");
		
		while (x <= NumofBoxesatOnce) {
			Vector3 RandomSpawn = new Vector3(Random.Range(0.0f, 500.0f),Random.Range(4.0f, 100.0f),Random.Range(0.0f, 500.0f));
			Instantiate (FireBox, RandomSpawn, Quaternion.identity);
			Vector3 RandomSpawn1 = new Vector3(Random.Range(0.0f, 500.0f),Random.Range(4.0f, 100.0f),Random.Range(0.0f, 500.0f));
			Instantiate (IceBox, RandomSpawn1, Quaternion.identity);
			Vector3 RandomSpawn3 = new Vector3(Random.Range(0.0f, 500.0f),Random.Range(4.0f, 100.0f),Random.Range(0.0f, 500.0f));
			Instantiate (GreenBox, RandomSpawn3, Quaternion.identity);
			Vector3 RandomSpawn4 = new Vector3(Random.Range(0.0f, 500.0f),Random.Range(4.0f, 100.0f),Random.Range(0.0f, 500.0f));
			Instantiate (PurpleBox, RandomSpawn3, Quaternion.identity);
			x++;

		}

		//UpdatePosition ();
	}
	

	/* void UpdatePosition () 
		{
		foreach (GameObject FireBox in FireBoxes)
		{
			FireBox.transform.Translate (RandomSpawn);
		
		}

		foreach (GameObject IceBox in IceBoxes)
		{
			IceBox.transform.Translate (RandomSpawn);

		}
	} 

	void LateUpdate()
	{
		UpdatePosition ();
	}
	*/
}
