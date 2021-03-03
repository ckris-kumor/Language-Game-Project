using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public void SceneChange (string SceneName)
	{
		Debug.Log ("Blue Rune = " + GlobalVar.BlueRune.ToString () + " Red Rune = " + GlobalVar.RedRune.ToString () + " Green Rune = " + GlobalVar.GreenRune.ToString () + " Purple Rune = " + GlobalVar.PurpleRune.ToString () + GlobalVar.WordDescription);
		Debug.Log ("You are in the SCeneChange function");
		SceneManager.LoadScene(SceneName);
		//Cursor.visible = true;
	}
}
