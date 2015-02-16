using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThoughtBubble : MonoBehaviour 
{
	public Text text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	[RPC]
	public void setStoredText(string _text)
	{
		text.text = _text;
	}
}
