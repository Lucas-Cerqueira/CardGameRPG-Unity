using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour {

	public enum Side 
	{none=0, left=-1, right=1}

	[Header("CardMovement")]
	public float maxAngle = 10.0f;
	public float maxXOffset = 300f;
	public float rotationSpeed = 5f;
	public float moveSpeed = 10f;
	public float distanceToMove = 5f;


	private CardBehind cardBehind;

	private Animation animation;

	static public Side currentSide = Side.none;
	private Vector3 initialMousePosition;
	private bool mouseOver = false;
	private bool movingCard = false;
	private Vector3 targetMovePosition;


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

			if (currentSide == Side.left || currentSide == Side.right)
			{
				// Left => currentSide = -1    |    Right => currentSide = 1
				//targetMovePosition = transform.position + transform.right * distanceToMove * ((int)currentSide);
				if (currentSide == Side.left)
					animation.clip = animation.GetClip ("selectedLeft");
				else
					animation.clip = animation.GetClip ("selectedRight");

				animation.Play ();
			
				// INSERT FUNCTION HERE TO UPDATE PLAYER STATS (FAME, GOLD,...)
				// UpdateStats (currentSide)

				cardBehind.FlipCard ();
				currentSide = Side.none;
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
				currentSide = Side.left;
			} else if (deltaX >= maxXOffset / 2f) {
				currentSide = Side.right;
			} else
				currentSide = Side.none;
			
		}
		else if (!movingCard && currentSide == Side.none)
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (Vector3.zero), Time.deltaTime * rotationSpeed);
		else 
		{
			//transform.position = Vector3.Lerp (transform.position, targetMovePosition, moveSpeed * Time.deltaTime);
		}
	}


}
