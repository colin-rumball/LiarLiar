using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public GameObject player1, player2, Murder, Mother;
	public Runner_Background spawner;
	public GameObject[] enemies;
	
	
	private int gameVariable;
	private float spawnTimer = 0.8f;
	private float gameTimer = 5.0f;
	private GameObject selectedEnemy;

	// Use this for initialization
	void Start () 
	{
		Global.GameCounter = 0;
		gameVariable = Global.GameVariable;
		switch (2)
		{
		case 0: //cat
			selectedEnemy = enemies[0];
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
			break;
		case 4: // drunk
			selectedEnemy = enemies[4];
			break;
		case 5: // ghost
			selectedEnemy = enemies[5];
			break;
		case 6: // spy
			selectedEnemy = enemies[6];
			break;
		case 7: // explosions
			selectedEnemy = enemies[7];
			break;
		case 8: // mother in law
			selectedEnemy = enemies[8];
			GameObject motherChaser = (GameObject) Instantiate(Mother, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			motherChaser.transform.SetParent(transform);
			break;
		default:
			selectedEnemy = enemies[2];
			GameObject motherChaser2 = (GameObject) Instantiate(Mother, new Vector3(-10.66f, -1.0f, 0.0f), Quaternion.Euler(0,0,0));
			motherChaser2.transform.SetParent(transform);
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

		if (gameTimer <= 0.0f || Global.GameCounter >= 3)
		{
			Global.GameResult = true;
			Application.LoadLevel("Interrogation");
		} //else
		//gameTimer -= Time.deltaTime;	
	}
}
