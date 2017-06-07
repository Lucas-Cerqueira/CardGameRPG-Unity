using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour {

	private Animation animation;
	private string text;
	private TMP_Text tmpText;

	public void Fade (string newText)
	{
		animation.Play ();
		text = newText;
	}

	// This function is called at the middle of the animation
	public void ChangeText ()
	{
		tmpText.text = text;
	}

	// Use this for initialization
	void Start () 
	{
		animation = GetComponent<Animation> ();
		tmpText = GetComponent<TMP_Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
