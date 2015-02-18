using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interrogation : MonoBehaviour 
{
	public GameObject copBubble, playersBubble, allAnswerBubbles, fader, canvas, player1Box, player2Box;
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

	private string playersResponse = "";
	
	// Use this for initialization
	void Start ()
	{
		allAnswerBubbles.SetActive(false);

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

		if (!PhotonNetwork.offlineMode)
		{
			if (PhotonNetwork.isMasterClient)
			{
				Destroy(player2Box.gameObject);
			} else
			{
				Destroy(player1Box.gameObject);
			}
		} else
		{
			Destroy(player2Box.gameObject);
			Destroy(player1Box.gameObject);
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
			leftBubbles[i].GetComponent<PhotonView>().RPC("setStoredText", PhotonTargets.All, leftAnswers[i]);
			rightBubbles[i].GetComponent<PhotonView>().RPC("setStoredText", PhotonTargets.All, rightAnswers[i]);
			//leftBubbles[i].GetComponentInChildren<Text>().text = leftAnswers[i];
			//rightBubbles[i].GetComponentInChildren<Text>().text = rightAnswers[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Global.GamePlaying = true;
			Global.GameVariable = 0;
			Application.LoadLevel("Platformer");
		}

		if (answersAvailable && answerTimer <= 0.0f)
		{
			if (leftSelection < 0  && (PhotonNetwork.isMasterClient || PhotonNetwork.offlineMode))
			{
				if (Input.GetKeyDown(KeyCode.A))
				{
					this.GetComponent<PhotonView>().RPC("setLeftSelection", PhotonTargets.All, 0);
					//leftSelection = 0;
				} else if (Input.GetKeyDown(KeyCode.W))
				{
					this.GetComponent<PhotonView>().RPC("setLeftSelection", PhotonTargets.All, 1);
					//leftSelection = 1;
				} else if (Input.GetKeyDown(KeyCode.D))
				{
					this.GetComponent<PhotonView>().RPC("setLeftSelection", PhotonTargets.All, 2);
					//leftSelection = 2;
				}
				
				/*if (leftSelection >= 0)
				{
					for (int i = 0; i < leftBubbles.Length; i++)
					{
						if ( i != leftSelection)
							Destroy(leftBubbles[i]);
					}
				}*/
			}
			
			if (rightSelection < 0 && (!PhotonNetwork.isMasterClient || PhotonNetwork.offlineMode))
			{
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					this.GetComponent<PhotonView>().RPC("setRightSelection", PhotonTargets.All, 0);
					//rightSelection = 0;
				} else if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					this.GetComponent<PhotonView>().RPC("setRightSelection", PhotonTargets.All, 1);
					//rightSelection = 1;
				} else if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					this.GetComponent<PhotonView>().RPC("setRightSelection", PhotonTargets.All, 2);
					//rightSelection = 2;
				}
				/*if (rightSelection >= 0)
				{
					for (int i = 0; i < rightBubbles.Length; i++)
					{
						if ( i != rightSelection)
							Destroy(rightBubbles[i]);
					}
				}*/
			}
			
			if (leftSelection >= 0 && rightSelection >= 0)
			{
				if (endingTimer <= 0.0f)
				{
					PhotonNetwork.LoadLevel("Instruction");
				} else
				{
					if (playersResponse != "")
					{
						playersBubble.SetActive(true);
						playersBubble.GetComponentInChildren<Text>().text = playersResponse;
						playersResponse = "";
					}
					endingTimer -= Time.deltaTime;
				}

				if (!typeAndVarSet)
				{
					if (PhotonNetwork.isMasterClient || PhotonNetwork.offlineMode)
					{
						if (gameTypeOnLeft)
						{
							this.GetComponent<PhotonView>().RPC("setGameVariable", PhotonTargets.All, 
							                                    answerGenerator.getVariableNumFromString(rightAnswers[rightSelection]));
							//Global.GameVariable = answerGenerator.getVariableNumFromString(rightAnswers[rightSelection]);
							this.GetComponent<PhotonView>().RPC("setLevelToLoad", PhotonTargets.All, 
							                                    answerGenerator.getTypeNumFromString(leftBubbles[leftSelection].GetComponentInChildren<Text>().text)+6);
							//Global.LevelToLoad = answerGenerator.getTypeNumFromString(leftBubbles[leftSelection].GetComponentInChildren<Text>().text)+6;
							//Application.LoadLevel(leftBubbles[leftSelection].GetComponentInChildren<Text>().text);
						} else
						{
							this.GetComponent<PhotonView>().RPC("setGameVariable", PhotonTargets.All, 
							                                    answerGenerator.getVariableNumFromString(leftAnswers[leftSelection]));
							//Global.GameVariable = answerGenerator.getVariableNumFromString(leftAnswers[leftSelection]);
							this.GetComponent<PhotonView>().RPC("setLevelToLoad", PhotonTargets.All, 
							                                    answerGenerator.getTypeNumFromString(rightBubbles[rightSelection].GetComponentInChildren<Text>().text)+6);
							//Global.LevelToLoad = answerGenerator.getTypeNumFromString(rightBubbles[rightSelection].GetComponentInChildren<Text>().text)+6;
							//Application.LoadLevel(rightBubbles[rightSelection].GetComponentInChildren<Text>().text);
						}

						this.GetComponent<PhotonView>().RPC("setInstruction", PhotonTargets.All, answerGenerator.getInstruction());
						this.GetComponent<PhotonView>().RPC("setPlayersBubble", PhotonTargets.All, answerGenerator.getSentence());
					}

					typeAndVarSet = true;
					Global.GamePlaying = true;
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
					if (PhotonNetwork.offlineMode || PhotonNetwork.isMasterClient)
					{
						fillAnswerBubbles();
					}
					allAnswerBubbles.SetActive(true);
					answersAvailable = true;
					background.sprite = bg2;
				}
			} else
				beginningTimer -= Time.deltaTime;
		}
	}

	[RPC]
	public void setLeftSelection(int _num)
	{
		leftSelection = _num;

		for (int i = 0; i < leftBubbles.Length; i++)
		{
			if ( i != leftSelection)
				Destroy(leftBubbles[i]);
		}
	}

	[RPC]
	public void setRightSelection(int _num)
	{
		rightSelection = _num;

		for (int i = 0; i < rightBubbles.Length; i++)
		{
			if ( i != rightSelection)
				Destroy(rightBubbles[i]);
		}
	}

	[RPC]
	public void setPlayersBubble(string _str)
	{
		playersResponse = _str;
	}

	[RPC]
	public void setInstruction(string _str)
	{
		Global.LevelInstruction = _str;
	}

	[RPC]
	public void setLevelToLoad(int _num)
	{
		Global.LevelToLoad = _num;
	}

	[RPC]
	public void setGameVariable(int _num)
	{
		Global.GameVariable = _num;
	}
}
