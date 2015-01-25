using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Button startButton;

	// Use this for initialization
	void Start () 
	{
		startButton.onClick.AddListener(() => startButtonClicked());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void startButtonClicked()
	{
		//Application.LoadLevel("Introduction");
	}
}
