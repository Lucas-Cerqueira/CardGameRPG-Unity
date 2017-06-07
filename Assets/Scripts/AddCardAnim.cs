using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardAnim : MonoBehaviour {

	private CardBehind cardBehindClass;
	private Animation animation;

	private bool flip = true;

	public void AddCardsNoFlip()
	{
		animation.Play ();
		flip = false;
	}

	public void AddCardsAndFlip()
	{
		animation.Play ();
		flip = true;
	}

	public void AddedCards()
	{
		if (flip)
			cardBehindClass.FlipCard ();
	}

	// Use this for initialization
	void Start ()
	{
		cardBehindClass = GameObject.Find ("CardBehind").GetComponent<CardBehind> ();
		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
