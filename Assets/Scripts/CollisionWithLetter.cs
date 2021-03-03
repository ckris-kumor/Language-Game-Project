using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithLetter : GibOnCollide {
	public GameObject RuneLetter;
	public GameObject LetterBlock;
	public GameObject Projectile;
	public string DesiredBlockTag;
	public string DesiredProjectileTag;





	IEnumerator OnCollisionEnter(Collision other)
	{
		Debug.Log ("Something is colliding with this cube");
		Debug.Log (other.gameObject.tag);
		if (LetterBlock.tag == DesiredBlockTag && other.gameObject.tag == DesiredProjectileTag) 
		{
			LetterBlock.GetComponent<Rigidbody>().useGravity = true;
			LetterBlock.GetComponent<Rigidbody> ().isKinematic = false;
			yield return new WaitForSeconds (4f);
			GameObject Exsplosion = Instantiate(gib,transform.position,transform.rotation);
			Destroy (Exsplosion,WaitingTime);
			Destroy (LetterBlock);
			GameObject ItemPickUp = Instantiate (RuneLetter, LetterBlock.transform.position, transform.rotation);
			if (!ItemPickUp.activeInHierarchy) 
			{
				ItemPickUp.SetActive (true);
			}


		}
	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		Debug.Log ("Something is colliding with this cube");
		Debug.Log (other.gameObject.tag);
		if (LetterBlock.tag == DesiredBlockTag && other.gameObject.tag == DesiredProjectileTag) 
		{
			Debug.Log ("It will be added to Inventory");
			
			LetterBlock.GetComponent<Rigidbody>().useGravity = true;
			LetterBlock.GetComponent<Rigidbody> ().isKinematic = false;
			yield return new WaitForSeconds (1f);
			GameObject Exsplosion = Instantiate(gib,transform.position,transform.rotation);
			Destroy (Exsplosion,WaitingTime);
			Destroy (LetterBlock);
			GameObject ItemPickUp = Instantiate (RuneLetter, LetterBlock.transform.position, transform.rotation);
			if (!ItemPickUp.activeInHierarchy) 
			{
				ItemPickUp.SetActive (true);
			}


		}
	}
}
