using UnityEngine;
using System.Collections;

public class TheGenerator : MonoBehaviour 
{

	private string[] gameTypes = {"Platformer", "Runner", "Driver", "FPS", "Avoidance", "Maze", "QTE", "Catcher", "Brawler"};
	private string[] gameVariables = {"Cat", "Astronaut", "Bananas", "Horror", "Drunk", "Ghost", "Spy", "Explosions", "Mother"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string[] getGameTypes()
	{
		int[] nums = {0, 1, 2, 3, 4, 5, 6, 7, 8};
		
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
		int[] nums = {0, 1, 2, 3, 4, 5, 6, 7, 8};
		
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
}
