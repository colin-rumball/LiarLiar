using UnityEngine;
using System.Collections;

public class TheGenerator : MonoBehaviour 
{

	private string[] gameTypes = {"Jumped", "Ran", "Drove", "Shot", "Avoided", "Lost", "Quickly", "Caught", "Fought"};
	private string[] gameVariables = {"Cat", "Space", "Bananas", "Horror", "Drunk", "Ghost", "Spy", "Explosions", "Mother In Law"};
	private string[,] gameInstructions = new string[9,9];
	private string[,] gameSentences = new string[9,9];

	// Use this for initialization
	void Start () {
		loadInstructions();
		loadSentences();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getTypeNumFromString(string str)
	{
		for (int i = 0; i < gameTypes.Length; i++)
		{
			if (str == gameTypes[i])
				return i;
		}
		Debug.LogError("Could not find type");
		return 0;
	}

	public int getVariableNumFromString(string str)
	{
		for (int i = 0; i < gameVariables.Length; i++)
		{
			if (gameVariables[i] == str)
				return i;
		}
		return -1;
	}
	
	public string[] getGameTypes()
	{
		int[] nums = {0, 1, 2, 4, 8};
		
		for (int i = nums.Length-1; i > 0; i--)
		{
			int rnd = Random.Range(0,i);
			
			int temp = nums[i];
			
			nums[i] = nums[rnd];
			nums[rnd] = temp;
		}
		
		string[] returnArr = {gameTypes[nums[0]], gameTypes[nums[1]], gameTypes[nums[2]]};
		return returnArr;
	}
	
	public string[] getGameVariables()
	{
		int[] nums = {0, 2, 3, 5, 6, 8};
		
		for (int i = nums.Length-1; i > 0; i--)
		{
			int rnd = Random.Range(0,i);
			
			int temp = nums[i];
			
			nums[i] = nums[rnd];
			nums[rnd] = temp;
		}
		
		string[] returnArr = {gameVariables[nums[0]], gameVariables[nums[1]], gameVariables[nums[2]]};
		return returnArr;
	}

	public string getInstruction()
	{
		return gameInstructions[Global.LevelToLoad-5,Global.GameVariable];
	}

	public string getSentence()
	{
		return gameSentences[Global.LevelToLoad-5,Global.GameVariable];
	}

	private void loadInstructions()
	{
		TextAsset txt = (TextAsset)Resources.Load("Instructions", typeof(TextAsset));
		string content = txt.text;
		string[] strA = content.Split('|');
		for (int i = 0; i < strA.Length; i++)
		{
			strA[i] = strA[i].Substring(1);
		}

		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				gameInstructions[i,j] = strA[(i*9)+j];
			}
		}
	}

	private void loadSentences()
	{
		TextAsset txt = (TextAsset)Resources.Load("Sentences", typeof(TextAsset));
		string content = txt.text;
		string[] strA = content.Split('|');
		for (int i = 0; i < strA.Length; i++)
		{
			strA[i] = strA[i].Substring(1);
		}
		
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				gameSentences[i,j] = strA[(i*9)+j];
			}
		}
	}
}
