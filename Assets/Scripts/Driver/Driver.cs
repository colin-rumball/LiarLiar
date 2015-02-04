using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour 
{
	public GameObject enemy;
	public Sprite[] sprites;
	public Transform[] spawnLocations;
	
	private int gameVariable;
	private Sprite selectedSprite;
	private float spawnTimer = 0.8f;
	private float gameTimer = 5.0f;

	// Use this for initialization
	void Start () {
		gameVariable = PlayerPrefs.GetInt("GameVariable");
		switch (gameVariable)
		{
		case 0:
			selectedSprite = sprites[0];
			enemy.AddComponent<Driver_Collectable>();
			break;
		case 1: 
			selectedSprite = sprites[1];
			break;
		case 2:
			selectedSprite = sprites[2];
			enemy.AddComponent<Driver_Obstacle>();
			break;
		case 3: 
			selectedSprite = sprites[3];
			enemy.AddComponent<Driver_Collectable>();
			break;
		case 4: 
			selectedSprite = sprites[4];
			enemy.AddComponent<Driver_Obstacle>();
			break;
		case 5:
			selectedSprite = sprites[5];
			enemy.AddComponent<Driver_Obstacle>();
			break;
		case 6:
			selectedSprite = sprites[6];
			break;
		case 7:
			selectedSprite = sprites[7];
			enemy.AddComponent<Driver_Obstacle>();
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
		if (spawnTimer <= 0.0f)
		{
			Vector3 pos = spawnLocations[Random.Range(0, 6)].transform.position;
			Quaternion rot = Quaternion.Euler(0,0,0);
			if (Random.Range(0, 2) == 1)
				rot = Quaternion.Euler(0,-180.0f,0);

			GameObject obj = (GameObject)Instantiate(enemy, pos, rot);
			obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;
			spawnTimer = Random.Range(8, 14)/10.0f;
		} else
			spawnTimer -= Time.deltaTime;

		if (gameTimer <= 0.0f)
		{
			PlayerPrefs.SetInt("Result", 1);
			Application.LoadLevel("Interrogation");
		} else
			gameTimer -= Time.deltaTime;
	}
}
