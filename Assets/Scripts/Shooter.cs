using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {

	private GameObject Bullet1;
	private int counter = 0;
	private bool PlatEnable = true;
	private GameObject Plat;
	private bool Destroyed;
	GameObject  GreenRuneCubeAreaCollider;
	public float v = 40;
	public GameObject Coll;
	public GameObject prefabFire1;
    public GameObject prefabFire2;
	public GameObject prefabFire3;
	public GameObject prefabFire4;
	public GameObject prefabFire5;
	public Vector3 Offset;
	GameObject GreenRuneCube;
	public GameObject StartPositionForLineRenderer;
	GameObject AlterAreaColider;
	GameObject Player;
	GameObject GreenRune;
	Light[]  GreenRuneLights;
	GameObject Map;
	GameObject Light;
	GameObject WordDescription;





	// Use this for initialization
	void Start () 
	{		
		AlterAreaColider = GameObject.FindGameObjectWithTag ("AltarArea");
		Player = GameObject.FindGameObjectWithTag("Player");
		Map = GameObject.FindGameObjectWithTag ("Environment");
		Light = GameObject.FindGameObjectWithTag ("Light");
		WordDescription = GameObject.FindGameObjectWithTag ("WordDescription");

	}



	
	// Update is called once per frame
	void FixedUpdate () {
		

		if (!GameObject.Find("PurpleBullet(Clone)")){
			GlobalVar.ExplosionCheck = 0;
		}

		if(!(AlterAreaColider.GetComponent<BoxCollider>().bounds.Contains(Player.transform.position)))
			{
			Debug.Log (GlobalVar.Check.ToString ());
				if (Input.GetMouseButtonDown (0) && GlobalVar.Check == 0) {
		            GameObject Bullet;
					Bullet = Instantiate (prefabFire1) as GameObject;
		            Bullet.transform.position = StartPositionForLineRenderer.transform.position + Offset + Camera.main.transform.forward * 2;
		            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
		            rb.velocity = Camera.main.transform.forward * v;

		        }
				if(Input.GetMouseButtonDown(0) && GlobalVar.Check == 1)
		            
		        {
		            GameObject Bullet;
		            Bullet = Instantiate(prefabFire2) as GameObject;
		            Bullet.transform.position = StartPositionForLineRenderer.transform.position + Offset + Camera.main.transform.forward * 2;
		            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
		            rb.velocity = Camera.main.transform.forward * v;
		        }

				if(Input.GetMouseButtonDown(0) && (GlobalVar.Check == 2) && (GlobalVar.ExplosionCheck != 1))

				{
					
					Bullet1 = Instantiate(prefabFire3) as GameObject;
					Bullet1.transform.position = StartPositionForLineRenderer.transform.position + Offset + Camera.main.transform.forward * 2;
					Rigidbody rb = Bullet1.GetComponent<Rigidbody>();
					rb.velocity = Camera.main.transform.forward * 5;
					GlobalVar.ExplosionCheck = 1;
					Destroy (Bullet1, 6);
				}
		    
				if(Input.GetMouseButtonDown(1) && (GlobalVar.Check == 2) && (GlobalVar.ExplosionCheck == 1) && PlatEnable == true)

				{

					Plat = Instantiate(prefabFire4) as GameObject;
					Plat.transform.position = Bullet1.transform.position;
					Destroy (Plat,10);

				}
				
				if(GlobalVar.Check == 3)
			{
				

					
				if (Input.GetMouseButtonDown (0)) {
						GameObject Bullet;
						Bullet = Instantiate (prefabFire5) as GameObject;
						Bullet.transform.position = StartPositionForLineRenderer.transform.position + Offset + Camera.main.transform.forward * 2;
						Rigidbody rb = Bullet.GetComponent<Rigidbody> ();
						rb.velocity = Camera.main.transform.forward * v;
					}





			}

			if (GlobalVar.Check == 4) 
			{
				if(Input.GetMouseButtonDown(0))
				{
					Debug.Log ("You should be activating the Nacht spell");
					if (WordDescription.GetComponent<Text> ().text.Trim() == "NACHT") {
						Nacht ();
						WordDescription.GetComponent<Text> ().text = "";
						GlobalVar.WordDescription = "";
					}
					if (WordDescription.GetComponent<Text> ().text.Trim() == "MORGEN") {
						Morgen ();
						WordDescription.GetComponent<Text> ().text = "";
						GlobalVar.WordDescription = "";
					}

				}
			 
			
    		}
	}
	}
	IEnumerator Wait()
	{

		yield return new WaitForSeconds (6);
		Destroy (Plat);
		counter = counter - 1;
			
	}
	void Nacht()
	{
		Debug.Log ("You ar ein the Nacht function");
		GlobalVar.SunsColor = Color.black;
		Light.GetComponent<Light> ().color = GlobalVar.SunsColor;

	}
		
	void Morgen()
	{
		Debug.Log ("You ar ein the Morgen function");
		GlobalVar.SunsColor = Color.yellow;
		Light.GetComponent<Light> ().color = GlobalVar.SunsColor;
	}

		
}

