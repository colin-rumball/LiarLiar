using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interrogation : MonoBehaviour 
{
	public GameObject copBubble, playersBubble, allAnswerBubbles, fader, canvas;
	public Image background;
	public Image[] strikes;
	public Sprite bg2;
	public Text gamesWon;
	public GameObject[] leftBubbles = new GameObject[3];
	public GameObject[] rightBubbles = new GameObject[3];
	
	public TheGenerator answerGenerator;

	public bool answersAvailable = false;
	
	private string[] leftAnswers = new string[3];
	private string[] rightAnswers = new string[3];
	
	private int leftSelection = -1;
	private int rightSelection = -1;
	
	private bool gameTypeOnLeft = false;
	private bool typeAndVarSet = false;

	private float endingTimer = 2.0f;
	private float beginningTimer = 2.0f;
	private float answerTimer = 1.5f;
	private float gameOverTimer = 3.0f;

	
	// Use this for initialization
	void Start ()
	{
		fillAnswerBubbles();
		if (Global.GamePlayed)
		{
			if (Global.GameResult)
			{
				copBubble.GetComponentInChildren<Text>().text = "I guess that makes sense... Then what happened?";
				Global.GamesWon++;
			} else
			{
				Global.GameStrikes++;
				if (Global.GameStrikes >= 3)
				{
					copBubble.GetComponentInChildren<Text>().text = "None of this is making any sense. You're coming with me!";
					background.sprite = bg2;
					Global.GameOver = true;
				} else
				{
					copBubble.GetComponentInChildren<Text>().text = "I don't believe you! Tell me the truth!";
				}
			}

			for (int i = 0; i < Global.GameStrikes && i < strikes.Length; i++)
			{
				strikes[i].color = new Color32(255, 255, 255, 255); 
			}
			gamesWon.text = Global.GamesWon.ToString();
		} else
		{
			fader.SetActive(false);
			Global.GamePlayed = true;
		}
	}

	void fillAnswerBubbles()
	{
		if (Mathf.FloorToInt(Random.Range(0,2)) == 1)
		{
			leftAnswers = answerGenerator.getGameTypes();
			rightAnswers = answerGenerator.getGameVariables();
			gameTypeOnLeft = true;
		} else
		{
			leftAnswers = answerGenerator.getGameVariables();
			rightAnswers = answerGenerator.getGameTypes();
			gameTypeOnLeft = false;
		}
		for (int i = 0; i < 3; i++)
		{
			leftBubbles[i].GetComponentInChildren<Text>().text = leftAnswers[i];
			rightBubbles[i].GetComponentInChildren<Text>().text = rightAnswers[i];
		}
		allAnswerBubbles.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Global.GamePlaying = true;
			Global.GameVariable = 3;
			Application.LoadLevel("Avoidance");
		}

		if (answersAvailable && answerTimer <= 0.0f)
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
				if (endingTimer <= 0.0f)
				{
					Global.GamePlaying = true;

					Global.LevelInstruction = answerGenerator.getInstruction();
					Application.LoadLevel("Instruction");
				} else
					endingTimer -= Time.deltaTime;

				if (!typeAndVarSet)
				{
					if (gameTypeOnLeft)
					{
						Global.GameVariable = answerGenerator.getVariableNumFromString(rightAnswers[rightSelection]);
						Global.LevelToLoad = answerGenerator.getTypeNumFromString(leftBubbles[leftSelection].GetComponentInChildren<Text>().text)+5;
						//Application.LoadLevel(leftBubbles[leftSelection].GetComponentInChildren<Text>().text);
					} else
					{
						Global.GameVariable = answerGenerator.getVariableNumFromString(leftAnswers[leftSelection]);
						Global.LevelToLoad = answerGenerator.getTypeNumFromString(rightBubbles[rightSelection].GetComponentInChildren<Text>().text)+5;
						//Application.LoadLevel(rightBubbles[rightSelection].GetComponentInChildren<Text>().text);
					}
					playersBubble.SetActive(true);
					playersBubble.GetComponentInChildren<Text>().text = answerGenerator.getSentence();
					typeAndVarSet = true;
				}
			}
		} else if (answersAvailable && answerTimer > 0.0f)
		{
			answerTimer -= Time.deltaTime;
		} else
		{
			if (beginningTimer <= 0.0f)
			{
				if (Global.GameOver)
				{
					if (gameOverTimer == 3.0f)
					{
						canvas.GetComponent<Animator>().Play("Interrogation_FadeOut");
						canvas.GetComponent<Animator>().playbackTime = 0.0f;
						background.sprite = bg2;
						gameOverTimer -= Time.deltaTime;
					} else if (gameOverTimer <= 0.0f)
					{
						Application.LoadLevel("GameOver");
					} else
						gameOverTimer -= Time.deltaTime;
				} else
				{
					allAnswerBubbles.SetActive(true);
					answersAvailable = true;
					background.sprite = bg2;
				}
			} else
				beginningTimer -= Time.deltaTime;
		}
	}
}
