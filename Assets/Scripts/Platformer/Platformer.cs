using UnityEngine;
using System.Collections;

public class Platformer : MonoBehaviour 
{
	public GameObject player1, player2, CatAI;
	public Platformer_Background spawner;
	public GameObject[] enemies;
	
	private int gameVariable;
	private float spawnTimer = 0.8f;
	private float gameTimer = 12.0f;
	private GameObject selectedEnemy;


	void Start () 
	{
		//PhotonNetwork.offlineMode = true;
		Global.GamePlaying = true;
		Global.GameCounter = 0;
		gameVariable = Global.GameVariable;
		switch (gameVariable)
		{
		case 0: //cat
			selectedEnemy = enemies[0];
			Instantiate(CatAI, new Vector3(-0.11f, -1.26f, -1.0f), Quaternion.Euler(0,0,0));
			break;
		case 1: // space
			selectedEnemy = enemies[1];
			break;
		case 2: // bananas
			selectedEnemy = enemies[2];
			break;
		case 3: // horror
			selectedEnemy = enemies[3];
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
			break;
		default:
			//selectedEnemy = enemies[0];
			//Instantiate(CatAI, new Vector3(-0.11f, -1.26f, -1.0f), Quaternion.Euler(0,0,0));
			break;
		}
		//Physics2D.IgnoreCollision(player1.collider2D, player2.collider2D);
		spawner.setObs(selectedEnemy);
		//player1.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
		//player2.GetComponent<DriverUserControl>().setGameVariable(gameVariable);
		if (!PhotonNetwork.offlineMode)
		{
			GameObject netPlayer1, netPlayer2;
			if (PhotonNetwork.isMasterClient) 
			{
				netPlayer1 = (GameObject) PhotonNetwork.Instantiate("Platformer_Player1", player1.transform.position, player1.transform.rotation, 0);
				netPlayer1.GetComponent<Rigidbody2D>().isKinematic = false;
				netPlayer1.GetComponent<SyncronizedObject>().setIOwn(true);
				this.GetComponent<SyncronizedObject>().setIOwn(true);
			} else
			{
				netPlayer2 = (GameObject) PhotonNetwork.Instantiate("Platformer_Player2", player2.transform.position, player1.transform.rotation, 0);
				netPlayer2.GetComponent<Rigidbody2D>().isKinematic = false;
				netPlayer2.GetComponent<SyncronizedObject>().setIOwn(true);
			}
			Destroy(player1.gameObject);
			Destroy(player2.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			/*if (gameTimer > 0.0f)
			{
				if (spawnTimer <= 0.0f)
				{
					Quaternion rot = Quaternion.Euler(0,0,0);
					if (Random.Range(0, 2) == 1)
						rot = Quaternion.Euler(0,-180.0f,0);
					
					//GameObject obj = (GameObject)Instantiate(enemy, nextSpawnLocation, rot);
					//setUpEnemy(obj);
					spawnTimer = Random.Range(8, 14)/10.0f;
				} else
					spawnTimer -= Time.deltaTime;
			}*/

			if (gameTimer <= 0.0f || Global.GameCounter >= 3)
			{
				this.GetComponent<PhotonView>().RPC("miniGameWon", PhotonTargets.All, null);
				//Global.GameResult = true;
				//Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			} else
				gameTimer -= Time.deltaTime;	
		}
	}

	[RPC]
	public void miniGameWon()
	{
		Global.GameResult = true;
		Global.GamePlaying = false;
	}

	/*void setUpEnemy(GameObject obj)
	{
		//obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;
		switch (gameVariable)
		{
		case 0: //cat
			obj.GetComponent<Driver_Obstacle>().enabled = true;
			obj.AddComponent<Die>();
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
	}*/
}
