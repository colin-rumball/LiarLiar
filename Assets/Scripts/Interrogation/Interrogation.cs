using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interrogation : MonoBehaviour 
{
	public GameObject speechBubble;
	public GameObject thoughtBubble;
	public Transform canvas;
	
	public TheGenerator answerGenerator;
	
	private float[] timers = {2.0f, 4.0f, 8.0f};
	private int[] speaker = {3, 1, 3};
	private string[] sentence = {"What do you think you're doing?",
		"What are we going to do now?",
		"Explain Yourself!"};
	private int currentBubble = 0;
	private bool answersAvailable = false;
	
	private float optionsTimer = 3.0f;
	
	private string[] leftAnswers = new string[3];
	private string[] rightAnswers = new string[3];
	
	private GameObject[] leftBubbles = new GameObject[3];
	private GameObject[] rightBubbles = new GameObject[3];
	
	private int leftSelection = -1;
	private int rightSelection = -1;
	
	private bool gameTypeLeft = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
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
				if (Input.GetKeyDown(KeyCode.J))
				{
					rightSelected = true;
					rightSelection = 0;
				} else if (Input.GetKeyDown(KeyCode.L))
				{
					rightSelected = true;
					rightSelection = 1;
				} else if (Input.GetKeyDown(KeyCode.I))
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
					Application.LoadLevel(leftBubbles[leftSelection].GetComponentInChildren<Text>().text);
					/*switch (leftBubbles[leftSelection].GetComponentInChildren<Text>().text)
					{
						case "Platformer":
							break;
						case "Runner": 
							break;
						case "Driver":
							Application.LoadLevel("Driver");
							break;
						case "FPS": 
							break;
						case "Avoidance": 
							break;
						case "Maze":
							break;
						case "QTE":
							break;
						case "Catcher":
							break;
						case "Brawler":
							break;
					}*/
				} else
					Application.LoadLevel(rightBubbles[rightSelection].GetComponentInChildren<Text>().text);
			}
		} else
		{
			for (int i = currentBubble; i < timers.Length; i++)
			{
				if (timers[i] > 0.0f)
					timers[i] -= Time.deltaTime;
				if (timers[i] <= 0.0f)
				{
					currentBubble++;
					Vector3 pos = Vector3.zero;
					switch (speaker[i])
					{
						case 1:
							pos = new Vector3(Screen.width/4, Screen.height/4, 0.0f);
							break;
						case 2:
							pos = new Vector3(3*(Screen.width/4), Screen.height/4, 0.0f);
							break;
						case 3:
							pos = new Vector3(Screen.width/2, 3*(Screen.height/4), 0.0f);
							break;
					}
					GameObject bub = (GameObject)Instantiate(speechBubble, pos,Quaternion.Euler(0, 0, 0));
					bub.transform.SetParent(canvas);
					bub.GetComponent<SpeechBubble>().setStoredText(sentence[i]);
				}
			}
			if (currentBubble == timers.Length)
			{
				optionsTimer -= Time.deltaTime;
				if (optionsTimer <= 0.0f)
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
					for (int j = 0; j < 3; j++)
					{
						Vector3 pos = Vector3.zero;
						switch (j)
						{
						case 0:
							pos = new Vector3(Screen.width/8, 2*(Screen.height/3), 0.0f);
							break;
						case 1:
							pos = new Vector3(Screen.width/4, 2*(Screen.height/3), 0.0f);
							break;
						case 2:
							pos = new Vector3(3*(Screen.width/8), 2*(Screen.height/3), 0.0f);
							break;
						}
						GameObject obj = (GameObject)Instantiate(thoughtBubble, pos,Quaternion.Euler(0, 0, 0));
						obj.transform.SetParent(canvas);
						obj.GetComponent<ThoughtBubble>().setStoredText(leftAnswers[j]);
						obj.tag = "LeftChoice";
						leftBubbles[j] = obj;
					}
					for (int j = 0; j < 3; j++)
					{
						Vector3 pos = Vector3.zero;
						switch (j)
						{
						case 0:
							pos = new Vector3(5*(Screen.width/8), 2*(Screen.height/3), 0.0f);
							break;
						case 1:
							pos = new Vector3(6*(Screen.width/8), 2*(Screen.height/3), 0.0f);
							break;
						case 2:
							pos = new Vector3(7*(Screen.width/8), 2*(Screen.height/3), 0.0f);
							break;
						}
						GameObject obj = (GameObject)Instantiate(thoughtBubble, pos,Quaternion.Euler(0, 0, 0));
						obj.transform.SetParent(canvas);
						obj.GetComponent<ThoughtBubble>().setStoredText(rightAnswers[j]);
						obj.tag = "RightChoice";
						rightBubbles[j] = obj;
					}
					answersAvailable = true;
				}
			}
		}
	}
}
