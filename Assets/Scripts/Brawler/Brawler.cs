using UnityEngine;
using System.Collections;

public class Brawler : MonoBehaviour {
	
	public GameObject enemy;
	public Sprite[] sprites;

	private int gameVariable;
	private Sprite selectedSprite;
	private float spawnTimer = 0.8f;
	private float gameTimer = 5.0f;

	// Use this for initialization
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
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0.0f)
		{
			Vector3 pos = Vector3.zero;
			Quaternion rot = Quaternion.Euler(0,0,0);
			if (Random.Range(0, 2) == 1)
			{
				pos = new Vector3(12.0f, -1.45f, -1.0f);
				rot = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			} else
			{
				pos = new Vector3(-12, -1.45f, -1.0f);
				rot = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}
			GameObject obj = (GameObject)Instantiate(enemy, pos, rot);
			obj.GetComponent<SpriteRenderer>().sprite = selectedSprite;

			if (gameVariable == 7)
			{
				obj.GetComponent<Brawler_Enemy>().setToRoll();
			}

			spawnTimer = Random.Range(4, 12)/10.0f;
		}

		if (gameTimer <= 0.0f)
		{
			PlayerPrefs.SetInt("Result", 1);
			Application.LoadLevel("Interrogation");
		} else
			gameTimer -= Time.deltaTime;
	}
}
