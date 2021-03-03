using UnityEngine;
using System.Collections;

public class GibOnCollide : MonoBehaviour
{
	public GameObject gib;
	public float WaitingTime;

	void OnCollisionEnter()
	{
		GameObject Exsplosion = Instantiate(gib,transform.position,transform.rotation);
		Destroy(gameObject);
		Destroy (Exsplosion,WaitingTime);

		GlobalVar.ExplosionCheck = 0;
	}
}
