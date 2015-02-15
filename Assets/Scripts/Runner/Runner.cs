using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public GameObject player1, player2, Murder, Ghost, Dog, Mother, Cat;
	public Runner_Background spawner;
	public GameObject[] enemies;
	
	
	private int gameVariable;
	private float spawnTimer = 0.8f;
	private float gameTimer = 9.0f;
	private GameObject selectedEnemy;

	// Use this for initialization
	void Start () 
	{
		Global.GameCounter = 0;
		gameVariable = Global.GameVariable;
		print (gameVariable);
		switch (gameVariable)
		{
		case 0: //cat
			selectedEnemy = enemies[0];
			Cat.SetActive(true);
			break;
		case 1: // space
			selectedEnemy = enemies[1];
			break;
		case 2: // bananas
			selectedEnemy = enemies[2];
			break;
		case 3: // horror
			selectedEnemy = enemies[3];
		 	GameObject murderChaser = (GameObject) Instantiate(Murder, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			murderChaser.transform.SetParent(transform);
			this.GetComponent<RunnerCameraScript>().setDistance(1.0f);
			break;
		case 4: // drunk
			selectedEnemy = enemies[4];
			break;
		case 5: // ghost
			selectedEnemy = enemies[5];
			GameObject ghostChaser = (GameObject) Instantiate(Ghost, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			ghostChaser.transform.SetParent(transform);
			this.GetComponent<RunnerCameraScript>().setDistance(1.0f);
			break;
		case 6: // spy
			selectedEnemy = enemies[6];
			GameObject dogChaser = (GameObject) Instantiate(Dog, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			dogChaser.transform.SetParent(transform);
			this.GetComponent<RunnerCameraScript>().setDistance(1.0f);
			break;
		case 7: // explosions
			selectedEnemy = enemies[7];
			break;
		case 8: // mother in law
			selectedEnemy = enemies[8];
			GameObject motherChaser = (GameObject) Instantiate(Mother, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			motherChaser.transform.SetParent(transform);
			this.GetComponent<RunnerCameraScript>().setDistance(1.0f);
			break;
		default:
			selectedEnemy = enemies[2];
			break;
		}
		//Physics2D.IgnoreCollision(player1.collider2D, player2.collider2D);
		spawner.setObs(selectedEnemy);
		//player1.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
		//player2.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if ((gameTimer <= 0.0f && gameVariable != 0) || Global.GameCounter >= 1)
			{
				Global.GameResult = true;
				Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			} else if (gameTimer <= 0.0f && gameVariable == 0)
			{
				Global.GameResult = false;
				Global.GamePlaying = false;
			} else
				gameTimer -= Time.deltaTime;	
		}
	}
}
