using UnityEngine;
using System.Collections;

[AddComponentMenu("Spawn/Spawn On Button")]
public class SpawnOnButton : MonoBehaviour
{
	public GameObject objectToSpawn1;
	public GameObject objectToSpawn2;
	public Vector3 Offset;
	public GameObject StartPositionForProjectile;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(1) && GlobalVar.Check == 0)
		{
			Instantiate(objectToSpawn1,StartPositionForProjectile.transform.position + Offset,transform.rotation);
		}
		if(Input.GetMouseButtonDown(1) && GlobalVar.Check == 1)
		{
			Instantiate(objectToSpawn2,StartPositionForProjectile.transform.position + Offset,transform.rotation);
		}
			
	}
}
