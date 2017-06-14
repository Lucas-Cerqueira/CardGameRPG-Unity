using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour {


	[Header("CardMovement")]
	public float maxAngle = 10.0f;
	public float maxXOffset = 300f;
	public float rotationSpeed = 5f;


	private CardBehind cardBehind;
	private Card cardClass;

	private Animation animation;

	static public Card.Side currentSide = Card.Side.none;
	private Vector3 initialMousePosition;
	private bool mouseOver = false;
	private bool movingCard = false;
	private Vector3 targetMovePosition;



	public void UpdateStats (Card.Side side)
	{
		
	}

	void OnMouseEnter()
	{
		mouseOver = true;
	}

	void OnMouseExit()
	{
		mouseOver = false;
	}

	// Use this for initialization
	void Start () 
	{
		cardClass = GameObject.Find ("Card").GetComponent<Card>();
		cardBehind = GameObject.Find ("CardBehind").GetComponent<CardBehind>();
		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mouseOver && Input.GetMouseButtonDown (0)) 
		{
			movingCard = true;
			initialMousePosition = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp (0)) 
		{
			movingCard = false;

			if (currentSide == Card.Side.left || currentSide == Card.Side.right)
			{
				if (currentSide == Card.Side.left)
					animation.clip = animation.GetClip ("selectedLeft");
				else
					animation.clip = animation.GetClip ("selectedRight");

				animation.Play ();
			
				// Update player stats based on current side
				cardClass.UpdatePlayerStats (currentSide);

				cardBehind.FlipCard ();
				currentSide = Card.Side.none;
			} 
		}


		if (Input.GetMouseButton (0) && movingCard)
		{
			float deltaX = (Input.mousePosition - initialMousePosition).x;
			deltaX = Mathf.Clamp (deltaX, -maxXOffset, maxXOffset);
			Vector3 targetEulerAngles = new Vector3 (0, 0, maxAngle * deltaX / maxXOffset * (-1));
			//Debug.Log (deltaX);
			Quaternion targetRotation = Quaternion.Euler (targetEulerAngles);  
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


			if (deltaX <= -maxXOffset / 2f) {
				currentSide = Card.Side.left;
			} else if (deltaX >= maxXOffset / 2f) {
				currentSide = Card.Side.right;
			} else
				currentSide = Card.Side.none;
			
		}
		else if (!movingCard && currentSide == Card.Side.none)
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (Vector3.zero), Time.deltaTime * rotationSpeed);
	}


}
