  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using  TMPro;
using UnityEngine.SceneManagement;

public class LetterUI : MonoBehaviour {
	public Button [] LetterBUttons = new Button[27];
	public GameObject Word;
	public Text BlueRuneCounter;
	public Text RedRuneCounter;
	public Text GreenRuneCounter;
	public Text PurpleRuneCounter;
	public string[] Words;
	GameObject WordDescription;
	 

	void Start () 
	{
		
		LetterBUttons = Button.FindObjectsOfType<Button> ();
		Word = GameObject.FindGameObjectWithTag("Word");
		EventSystem eventSystem = EventSystem.FindObjectOfType<EventSystem> ();
		Cursor.visible = true;
		UpdateRuneNumbers ();
		WordDescription = GameObject.FindGameObjectWithTag ("WordDescription");


	}

	public void LetterSelected()
	{
//		if (GlobalVar.BlueRune == null && GlobalVar.RedRune == null && GlobalVar.GreenRune == null && GlobalVar.PurpleRune == null) {
//			GlobalVar.BlueRune = 0;
//			GlobalVar.RedRune = 0;
//			GlobalVar.PurpleRune = 0;
//			GlobalVar.GreenRune = 0;
//		}
		
		for (int i = 0; i < LetterBUttons.Length; i++) 
		{
			//Debug.Log (EventSystem.current.currentSelectedGameObject.name);


			if (EventSystem.current.currentSelectedGameObject.name == LetterBUttons[i].name) 
			{
				
				Text Letters = LetterBUttons[i].GetComponentInChildren<Text> ();


				if(LetterBUttons[i].tag != "Enter"&&LetterBUttons[i].tag != "Backspace"&&LetterBUttons[i].tag != "Change Scene"&& Word.GetComponent<TextMeshProUGUI> ().text == "")
				{

					Word.GetComponent<TextMeshProUGUI> ().text =  Letters.text + "\u00a0";

					return;

				}




				if(LetterBUttons[i].tag != "Enter"&& Word.GetComponent<TextMeshProUGUI> ().text != "" && LetterBUttons[i].tag != "Backspace"&&LetterBUttons[i].tag != "Change Scene")
				{
//					Debug.Log (Word.GetComponent<TextMeshProUGUI> ().text.ToString()+ "Already Added letters");
//
//					Debug.Log("Letter being added" + Letters.text);
					Word.GetComponent<TextMeshProUGUI> ().text = Word.GetComponent<TextMeshProUGUI> ().text.Trim () + Letters.text;

//					Debug.Log (Word.GetComponent<TextMeshProUGUI> ().text);


				}
				if (LetterBUttons [i].tag == "Enter") 
				{
//					Debug.Log ("You pressed enter");
//					Debug.Log (GlobalVar.BlueRune.ToString ());
//					Debug.Log (GlobalVar.RedRune.ToString ());
//					Debug.Log (GlobalVar.PurpleRune.ToString ());
//					Debug.Log (GlobalVar.GreenRune.ToString ());
					foreach (string word in Words) {
						Debug.Log (word);
						Debug.Log (Word.GetComponent<TextMeshProUGUI> ().text);
						if (word.ToUpper ().Trim() == Word.GetComponent<TextMeshProUGUI> ().text.Trim ()) {
							if (GlobalVar.BlueRune != 0 && GlobalVar.RedRune != 0 && GlobalVar.GreenRune != 0 && GlobalVar.PurpleRune != 0) {
								Debug.Log ("Forming your Word");
								WordDescription.GetComponent<Text> ().text = Word.GetComponent<TextMeshProUGUI> ().text.Trim ();
								WordDescription.GetComponent<Text> ().text.Trim ();
								Word.GetComponent<TextMeshProUGUI> ().text = "";
								DecrementRuneNumbers ();
								UpdateRuneNumbers ();
							} 
							else {
								Debug.Log ("You do not have enough rune to make this happen.");

								Word.GetComponent<TextMeshProUGUI> ().text = "You do not have enough rune to make this happen.";
								Waiting (100f);
								Word.GetComponent<TextMeshProUGUI> ().text = "";
						
							}


								
						} 


					
					}



				}

				if (LetterBUttons [i].tag == "Backspace" && Word.GetComponent<TextMeshProUGUI> ().text.Length !=0) {
					Debug.Log ("You should see a letter gone");
					string trimmedword = Word.GetComponent<TextMeshProUGUI> ().text.Trim ();
					Debug.Log (trimmedword);
					trimmedword = trimmedword.Substring (0, trimmedword.Length - 1);
					Debug.Log (trimmedword);
					Word.GetComponent<TextMeshProUGUI> ().text = trimmedword;
					Word.GetComponent<TextMeshProUGUI> ().text.Trim ();
				}
				if (LetterBUttons [i].tag == "Change Scene") {
					GlobalVar.WordDescription = WordDescription.GetComponent<Text> ().text.Trim ();
					Debug.Log ("Scene Change");
					Debug.Log (GlobalVar.WordDescription);
					WordDescription.GetComponent<Text> ().text = "";
					SceneManager.LoadScene("Adam Magic");
					
				}




			}
		}
	}

	void UpdateRuneNumbers()
	{
		BlueRuneCounter.text = GlobalVar.BlueRune.ToString ();
		RedRuneCounter.text = GlobalVar.RedRune.ToString ();
		GreenRuneCounter.text = GlobalVar.GreenRune.ToString ();
		PurpleRuneCounter.text = GlobalVar.PurpleRune.ToString ();
	}

	void DecrementRuneNumbers()
	{
		GlobalVar.BlueRune--;
		GlobalVar.RedRune--;
		GlobalVar.GreenRune--;
		GlobalVar.PurpleRune--;
	}


	IEnumerator Waiting (float delayofseconds)
	{
		yield return new WaitForSeconds(delayofseconds);
	}

}