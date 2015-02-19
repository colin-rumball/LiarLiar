using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Leaderboard : MonoBehaviour 
{
	public Text leaderboardText1, leaderboardText2, numbers1, numbers2;
	private string[] defaultLeaderboardNames = {"CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL"};
	private int[] defaultLeaderboardScores = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
	private string[] leaderboardNames = {"CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL"};
	private int[] leaderboardScores = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
	// Use this for initialization
	void Start () 
	{
		leaderboardNames = Leaderboard.loadLeaderboardNames();
		leaderboardScores = Leaderboard.loadLeaderboardScores();

		for (int i = 0; i < 5; i++)
		{
			if (leaderboardNames[i] != "" && leaderboardScores[i] != 0)
			{
				leaderboardText1.text += "" + (i+1).ToString("00") + ".  " + leaderboardNames[i];
				numbers1.text += leaderboardScores[i].ToString("000");
			}
			else
			{
				leaderboardText1.text += "" + (i+1).ToString("00") + ".  " + defaultLeaderboardNames[i];
				numbers1.text += defaultLeaderboardScores[i].ToString("000");
			}

			if (i < 4)
			{
				leaderboardText1.text += "\n";
				numbers1.text += "\n";
			}
		}
		for (int i = 5; i < 10; i++)
		{
			if (leaderboardNames[i] != "" && leaderboardScores[i] != 0)
			{
				leaderboardText2.text += "" + (i+1).ToString("00") + ".  " + leaderboardNames[i];
				numbers2.text += leaderboardScores[i].ToString("000");
			}
			else
			{
				leaderboardText2.text += "" + (i+1).ToString("00") + ".  " + defaultLeaderboardNames[i];
				numbers2.text += defaultLeaderboardScores[i].ToString("000");
			}

			if (i < 9)
			{
				leaderboardText2.text += "\n";
				numbers2.text += "\n";
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void returnToMainMenu()
	{
		Application.LoadLevel("MainMenu");
	}

	public static void reset()
	{
		string[] leaderboardNames = {"CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL"};
		int[] leaderboardScores = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
		for (int i = 0; i < leaderboardNames.Length; i++)
		{
			PlayerPrefs.SetString("PositionNames"+i.ToString(), leaderboardNames[i]);
			PlayerPrefs.SetInt("PositionScore"+i.ToString(), leaderboardScores[i]);
		}
	}

	public static int[] loadLeaderboardScores()
	{
		int[] scores = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
		for (int i = 0; i < 10; i++)
		{
			int loadedScore = PlayerPrefs.GetInt("PositionScore"+i.ToString());
			if (loadedScore != 0)
				scores[i] = loadedScore;
		}
		return scores;
	}

	public static string[] loadLeaderboardNames()
	{
		string[] names = {"CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL", "CJR & NL"};
		for (int i = 0; i < 10; i++)
		{
			string loadedName = PlayerPrefs.GetString("PositionNames"+i.ToString());
			if (loadedName != "")
				names[i] = loadedName;
		}
		return names;
	}

	public static void saveToLeaderboard(string _player1Name, string _player2Name, int _numberOfWins)
	{
		_player1Name = _player1Name.ToUpper();
		_player2Name = _player2Name.ToUpper();

		int[] scores = loadLeaderboardScores();
		string[] names = loadLeaderboardNames();
		for (int i = 0; i < scores.Length; i++)
		{
			if (scores[i] < _numberOfWins)
			{
				string tempName = _player1Name + " & " + _player2Name;
				int tempScore = _numberOfWins;
				for (int j = i; j < scores.Length; j++)
				{
					PlayerPrefs.SetString("PositionNames"+j.ToString(), tempName);
					PlayerPrefs.SetInt("PositionScore"+j.ToString(), tempScore);
		            tempName = names[j];
		            tempScore = scores[j];
				}
				return;
			}
		}
	}
}
