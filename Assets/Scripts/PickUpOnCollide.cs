using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpOnCollide : MonoBehaviour {
	
	public GameObject item;
	private Inventory MyInventory = new Inventory();


//	public  Item Item;
//	public GameObject Player;
//	public Image ImageofItem;
//	public Sprite SpriteImage;

	public void OnCollisionEnter()
	{
		Debug.Log ("Im adding" + item.tag + " to the inventory");
		MyInventory.AddItem (item);
		//Debug.Log ("On my Way to the Update Function Inventory");
		MyInventory.UpdateInventory ();
		//Debug.Log ("Im past UpdateInventory():");
		Destroy (item);
		
	}
		
		
}
