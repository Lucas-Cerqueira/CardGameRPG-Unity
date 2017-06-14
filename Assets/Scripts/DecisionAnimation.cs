using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecisionAnimation : MonoBehaviour {

	private Animation animation;

	private TMPro.TMP_Text decisionText;

	private Card.Side previousValue = Card.Side.none;
	private Card.Side currentValue = Card.Side.none;

	private Card cardClass;

	// Use this for initialization
	void Start () 
	{
		animation = GetComponent<Animation> ();
		decisionText = GetComponentInChildren<TMPro.TMP_Text> ();
		cardClass = GameObject.Find ("Card").GetComponent<Card> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentValue = CardInteraction.currentSide;

		if (currentValue != previousValue) 
		{
			string [] decisionsText = cardClass.GetDecisionsText();
			animation.clip = animation.GetClip ("showDecision");
			if (currentValue == Card.Side.none) 
			{
				animation.clip = animation.GetClip ("hideDecision");
			}
			else if (currentValue == Card.Side.left) 
			{
				decisionText.SetText ((cardClass.GetDecisionsText())[0]);
			}
			else
				decisionText.SetText ((cardClass.GetDecisionsText())[1]);

			animation.Play ();
		}

		previousValue = currentValue;
	}
}
