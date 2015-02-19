using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text gamesWon, player1Input, player2Input;

	// Use this for initialization
	void Start () {
		gamesWon.text = Global.GamesWon.ToString();;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void ReturnToMainMenu()
	{
		if (player1Input.text.Length >= 2 && player1Input.text.Length <= 3 && 
		    player2Input.text.Length >= 2 && player2Input.text.Length <= 3)
		{
			Leaderboard.saveToLeaderboard(player1Input.text, player2Input.text, Global.GamesWon);
			Application.LoadLevel("Leaderboard");
		}
	}
}
