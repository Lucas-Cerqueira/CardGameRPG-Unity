using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour {

	public Sprite debugSprite;

	// Class attributes
	private string title;
	private string description;
	private Sprite image;
	private string[] decisionsText = new string[2]; // left := 0  | right := 1

	// Object references
	private GameObject titleObj;
	private GameObject descriptionObj;
	private GameObject imageObj;
	private GameObject decisionObj;

	// Control varaibles
	private Vector3 imageStartPosition;

	public string GetTitle()
	{
		return title;
	}

	public void SetTitle(string newTitle)
	{
		title = newTitle;
		titleObj.GetComponent<UpdateText> ().Fade (title);
	}

	public string GetDescription()
	{
		return description;
	}

	public void SetDescription(string newDescription)
	{
		description = newDescription;
		descriptionObj.GetComponent<UpdateText> ().Fade (description);
	}

	public Sprite GetImage()
	{
		return image;
	}

	public void SetImage(Sprite newImage)
	{
		image = newImage;
	}

	public string[] GetDecisionsText()
	{
		return decisionsText;
	}

	public void SetDecisionsText(string[] newDecisionsText)
	{
		decisionsText[0] = newDecisionsText [0];
		decisionsText[1] = newDecisionsText [1];
	}

	int i = 0;
	// This function is called while the CardBehind is flipping
	public void SetupNextCard()
	{
		// INSERT HERE CODE TO UPDATE CARD ATTRIBUTES BASED ON THE NEXT CARD
		//
		// SetTitle (newTitle)
		// SetDescription (newDescription)
		// ...


		//////// DEBUG ////////
		if (i == 0) 
		{
			SetTitle ("Um Ladrao");
			SetDescription ("Um ladrao te intimida para roubar seu dinheiro, o que você faz?");
			SetDecisionsText (new string[2] {"Entrega o dinheiro", "Luta"});
			SetImage (imageObj.transform.GetChild(0).GetComponent<SpriteRenderer> ().sprite);
			i++;
		}
		else
		{
			SetTitle ("Um Sacerdote");
			SetDescription ("Você tem um tempo para ouvir a palavra do nosso Deus Sol?");
			SetDecisionsText (new string[2] {"Nao", "Praise the sun!"});
			SetImage (debugSprite);
		}

		//////////////////////

		print ("Next card set up");
	}

//	public void DeactivateNextCard()
//	{
//		imageObj.GetComponent<BoxCollider2D> ().enabled = false;
//		//imageObj.transform.GetChild(0).GetComponent<SpriteRenderer> ().enabled = false;
//		print ("Next card deactivated");
//	}

	// This function is called after the CardBehind has flipped
	public void ActivateNextCard()
	{
		imageObj.GetComponent<BoxCollider2D> ().enabled = true;
		imageObj.transform.GetChild(0).GetComponent<SpriteRenderer> ().sprite = image;
		imageObj.transform.GetChild(0).GetComponent<SpriteRenderer> ().enabled = true;
		print ("Next card activated");
	}

	// Use this for initialization
	void Start () 
	{
		titleObj = GameObject.Find ("CardTitle");
		descriptionObj = GameObject.Find ("CardDescription");
		imageObj = GameObject.Find ("CardImage");
		decisionObj = GameObject.Find ("CardDecision");

		imageStartPosition = imageObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
