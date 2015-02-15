using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour 
{
	public GameObject player1, player2;
	public GameObject[] enemies, objects;
	public Transform[] spawnLocations;
	
	private int gameVariable;
	private float spawnTimer = 1.5f;
	private float gameTimer = 9.0f;

	// Use this for initialization
	void Start () 
	{
		gameVariable = Global.GameVariable;
		gameVariable = 0;
		Global.GamePlaying = true;
		Vector3 pos1 = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
		Vector3 pos2 = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
		do
		{
			pos2 = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
		} while (pos2 == pos1);
		GameObject obj1 = (GameObject) Instantiate(enemies[gameVariable], pos1, Quaternion.Euler(0.0f, 0.0f, 0.0f));
		obj1.GetComponent<Catcher_Enemy>().setPlayers(player1, player2);
		GameObject obj2 = (GameObject) Instantiate(objects[gameVariable], pos2, Quaternion.Euler(0.0f, 0.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (gameTimer <= 0.0f)
			{
				Global.GameResult = false;
				//Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			} else
				gameTimer -= Time.deltaTime;
		}
	}
}
