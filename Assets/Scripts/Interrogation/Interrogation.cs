using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interrogation : MonoBehaviour 
{
	//public GameObject cop_speechBubble;
	//public GameObject speechBubble;
	//public GameObject thoughtBubble;
	//public GameObject background;
	//public Transform canvas;

	public GameObject[] leftBubbles = new GameObject[3];
	public GameObject[] rightBubbles = new GameObject[3];
	
	public TheGenerator answerGenerator;

	public bool answersAvailable = false;

	private string[] sentence = {"What do you think you're doing?",
		"What are we going to do now?",
		"Explain Yourself!"};
	
	private string[] leftAnswers = new string[3];
	private string[] rightAnswers = new string[3];
	
	private int leftSelection = -1;
	private int rightSelection = -1;
	
	private bool gameTypeLeft = false;
	
	// Use this for initialization
	void Start () 
	{
		fillAnswerBubbles();
		switch (PlayerPrefs.GetInt("Result"))
		{
		case 0:
			break;
		case 1:
			break;
		default:
			break;
		}
		Debug.Log(PlayerPrefs.GetInt("Result"));
	}

	void fillAnswerBubbles()
	{
		if (Mathf.FloorToInt(Random.Range(0,2)) == 1)
		{
			leftAnswers = answerGenerator.getGameTypes();
			rightAnswers = answerGenerator.getGameVariables();
			gameTypeLeft = true;
		} else
		{
			leftAnswers = answerGenerator.getGameVariables();
			rightAnswers = answerGenerator.getGameTypes();
			gameTypeLeft = false;
		}
		for (int i = 0; i < 3; i++)
		{
			leftBubbles[i].GetComponentInChildren<Text>().text = leftAnswers[i];
			rightBubbles[i].GetComponentInChildren<Text>().text = rightAnswers[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			PlayerPrefs.SetInt("GameVariable", 2);
			Application.LoadLevel("Driver");
		}

		if (answersAvailable)
		{
			if (leftSelection < 0)
			{
				bool leftSelected = false;
				if (Input.GetKeyDown(KeyCode.A))
				{
					leftSelected = true;
					leftSelection = 0;
				} else if (Input.GetKeyDown(KeyCode.W))
				{
					leftSelected = true;
					leftSelection = 1;
				} else if (Input.GetKeyDown(KeyCode.D))
				{
					leftSelected = true;
					leftSelection = 2;
				}
				
				if (leftSelected)
				{
					for (int i = 0; i < leftBubbles.Length; i++)
					{
						if ( i != leftSelection)
							Destroy(leftBubbles[i]);
					}
				}
			}
			
			if (rightSelection < 0)
			{
				bool rightSelected = false;
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					rightSelected = true;
					rightSelection = 0;
				} else if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					rightSelected = true;
					rightSelection = 1;
				} else if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					rightSelected = true;
					rightSelection = 2;
				}
				if (rightSelected)
				{
					for (int i = 0; i < rightBubbles.Length; i++)
					{
						if ( i != rightSelection)
							Destroy(rightBubbles[i]);
					}
				}
			}
			
			if (leftSelection >= 0 && rightSelection >= 0)
			{
				if (gameTypeLeft)
				{
					PlayerPrefs.SetInt("GameVariable", answerGenerator.getVariableNumFromString(rightAnswers[rightSelection]));
					Application.LoadLevel(leftBubbles[leftSelection].GetComponentInChildren<Text>().text);
				} else
				{
					PlayerPrefs.SetInt("GameVariable", answerGenerator.getVariableNumFromString(leftAnswers[leftSelection]));
					Application.LoadLevel(rightBubbles[rightSelection].GetComponentInChildren<Text>().text);
				}
			}
		}
	}
}
