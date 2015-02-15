using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text gamesWon;

	// Use this for initialization
	void Start () {
		gamesWon.text = Global.GamesWon.ToString();;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnToMainMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
