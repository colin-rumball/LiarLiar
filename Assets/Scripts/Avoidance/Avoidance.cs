using UnityEngine;
using System.Collections;

public class Avoidance : MonoBehaviour 
{
	public GameObject enemy, tombstone;
	public Sprite[] sprites;
	public Transform[] spawnLocations;

	private int gameVariable;
	private Sprite selectedSprite;
	private float spawnTimer = 1.5f;
	private float gameTimer = 9.0f;

	void Start () {
		gameVariable = Global.GameVariable;
		switch (gameVariable)
		{
			case 0:
			selectedSprite = sprites[0];
				break;
			case 1: 
			selectedSprite = sprites[1];
				break;
			case 2:
			selectedSprite = sprites[2];
				break;
			case 3: 
			selectedSprite = sprites[3];
				break;
			case 4: 
			selectedSprite = sprites[4];
				break;
			case 5:
			selectedSprite = sprites[5];
				break;
			case 6:
			selectedSprite = sprites[6];
				break;
			case 7:
			selectedSprite = sprites[7];
				break;
			case 8:
			selectedSprite = sprites[8];
				break;
		default:
			selectedSprite = sprites[1];
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (spawnTimer <= 0.0f)
			{
				Vector3 pos = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
				GameObject obj = (GameObject) Instantiate(enemy, pos, Quaternion.Euler(0.0f, 0.0f, 0.0f));
				if (gameVariable == 3 || gameVariable == 5)
					Instantiate(tombstone, pos, Quaternion.Euler(0.0f, 0.0f, 0.0f));
				obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;

				spawnTimer = 1.5f;
			} else
				spawnTimer -= Time.deltaTime;

			if (gameTimer <= 0.0f)
			{
				Global.GameResult = true;
				Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			} else
				gameTimer -= Time.deltaTime;
		}
	}
}
