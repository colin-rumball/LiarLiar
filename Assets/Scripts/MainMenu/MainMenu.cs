using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void StartGame()
	{
		Global.GameStrikes = 0;
		Global.GamesWon = 0;
		Global.GameResult = true;
		Global.GamePlayed = false;
		Global.GameOver = false;
		Application.LoadLevel("Introduction");
	}

	public void HowToPlay()
	{
		Application.LoadLevel("HowToPlay");
	}

	public void LeaderBoard()
	{
		Application.LoadLevel("Leaderboard");
	}
}
