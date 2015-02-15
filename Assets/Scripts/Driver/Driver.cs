using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour 
{
	public GameObject player1, player2;
	public GameObject enemy, motherInLaw, background, warning;
	public Sprite[] sprites;
	public Transform[] spawnLocations;

	private Vector3 nextSpawnLocation;
	private int gameVariable;
	private Sprite selectedSprite;
	private float warningTimer = 0.4f, spawnTimer = 0.8f;
	private float gameTimer = 8.0f;

	// Use this for initialization
	void Start () 
	{
		Global.GameCounter = 0;
		gameVariable = Global.GameVariable;
		switch (gameVariable)
		{
		case 0: //cat
			selectedSprite = sprites[0];
			break;
		case 1: // space
			selectedSprite = sprites[1];
			break;
		case 2: // bananas
			selectedSprite = sprites[2];
			break;
		case 3: // horror
			selectedSprite = sprites[3];
			break;
		case 4: // drunk
			selectedSprite = sprites[4];
			break;
		case 5: // ghost
			selectedSprite = sprites[5];
			GameObject ghost = (GameObject)Instantiate(enemy, new Vector3(6.59f, -2.54f, -1.0f), Quaternion.Euler(0.0f,0.0f,0.0f));
			ghost.AddComponent<Driver_GhostAI>();
			ghost.GetComponent<SpriteRenderer>().sprite = selectedSprite;
			ghost.GetComponent<Driver_GhostAI>().setGoingRight(false);
			ghost.AddComponent<Die>();
			ghost = (GameObject)Instantiate(enemy, new Vector3(-6.63f, 4.48f, -1.0f), Quaternion.Euler(0.0f,0.0f,0.0f));
			ghost.AddComponent<Driver_GhostAI>();
			ghost.GetComponent<SpriteRenderer>().sprite = selectedSprite;
			ghost.GetComponent<Driver_GhostAI>().setGoingRight(true);
			ghost.AddComponent<Die>();
			break;
		case 6: // spy
			gameTimer = 10.0f;
			selectedSprite = sprites[6];
			GameObject obj = (GameObject)Instantiate(enemy, new Vector3(-1.03f, -2.5f, -1.0f), Quaternion.Euler(0.0f,0.0f,0.0f));
			obj.GetComponent<Driver_SpyAI>().enabled = true;
			obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;
			obj.GetComponent<Driver_SpyAI>().setPlayers(player1, player2);
			obj.AddComponent<Die>();
			break;
		case 7: // explosions
			selectedSprite = sprites[7];
			break;
		case 8: // mother in law
			selectedSprite = sprites[6];
			break;
		default:
			selectedSprite = sprites[1];
			break;
		}
		player1.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
		player2.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
		nextSpawnLocation = spawnLocations[Random.Range(0, 6)].transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (gameVariable != 6 && gameTimer > 0.0f)
			{
				if (spawnTimer <= 0.0f)
				{
					Quaternion rot = Quaternion.Euler(0,0,0);
					if (Random.Range(0, 2) == 1)
						rot = Quaternion.Euler(0,-180.0f,0);

					GameObject obj = (GameObject)Instantiate(enemy, nextSpawnLocation, rot);
					setUpEnemy(obj);
					spawnTimer = Random.Range(8, 14)/10.0f;
					warningTimer = spawnTimer/2.0f;
				} else
					spawnTimer -= Time.deltaTime;

				if (warningTimer <= 0.0f)
				{
					nextSpawnLocation = spawnLocations[Random.Range(0, 6)].transform.position;
					GameObject obj = (GameObject)Instantiate(warning, nextSpawnLocation, Quaternion.Euler(0,0,0));
					obj.GetComponent<Driver_Warning>().setLifeTime(spawnTimer);
					warningTimer = 99.9f;
				} else
					warningTimer -= Time.deltaTime;
			}

			if (gameTimer <= 0.0f || (Global.GameCounter >= 3 && (gameVariable == 0 || gameVariable == 3)))
			{
				Global.GameResult = true;
				if (gameVariable != 8)
				{
					Global.GamePlaying = false;
					//Application.LoadLevel("Interrogation");
				}
				else
				{
					background.GetComponent<Background>().startStopping();
					GameObject obj = (GameObject)Instantiate(motherInLaw, new Vector3(8.52f, 9.0f, -1.0f), Quaternion.Euler(0,0,0));
					obj.GetComponent<Driver_MotherAI>().setPlayers(player1, player2);
					this.enabled = false;
				}
			} else if ((Global.GameCounter < 3 && (gameVariable == 0 || gameVariable == 3)))
			{
				Global.GameResult = false;
				Global.GamePlaying = false;
			} else
				gameTimer -= Time.deltaTime;
		}
	}

	void setUpEnemy(GameObject obj)
	{
		obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;
		switch (gameVariable)
		{
		case 0: //cat
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Collect>();
			break;
		case 1: // space
			break;
		case 2: // bananas
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
			break;
		case 3: // horror
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Collect>();
			break;
		case 4: // drunk
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
			break;
		case 5: // ghost
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
			break;
		case 7: // explosions
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
			break;
		case 8: // mother in law
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
			break;
		}
	}
}
