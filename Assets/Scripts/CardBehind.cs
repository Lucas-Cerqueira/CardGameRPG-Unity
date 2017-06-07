using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehind : MonoBehaviour {

	// Main card references
	private GameObject cardObj;
	private Card cardClass;


	private Sprite defaultSprite;
	private Animation animation;
	private SpriteRenderer spriteRenderer;

	public void FlipCard()
	{
		cardClass.SetupNextCard ();
		animation.clip = animation.GetClip ("flipCard");
		animation.Play ();
	}

	// Change CardBehind image, but it is just an image
	// The real card will be activated later
	public void ChangeBehindCardImage ()
	{
		CardInteraction.currentSide = CardInteraction.Side.none;


		Sprite cardSprite = cardClass.GetImage ();
		if (cardSprite)
			spriteRenderer.sprite = cardSprite;
	}

	public void CardFlipped ()
	{
		cardClass.ActivateNextCard ();
		spriteRenderer.sprite = defaultSprite;
	}

	// Use this for initialization
	void Start () 
	{
		// Setup card references
		cardObj = GameObject.Find ("Card");
		cardClass = cardObj.GetComponent<Card> ();

		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		defaultSprite = spriteRenderer.sprite;

		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
