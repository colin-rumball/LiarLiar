using UnityEngine;
using System.Collections;

public class Runner_Background : MonoBehaviour {

	public GameObject road, wall1, wall2, wall3, door, door2, window1, alley, spawner;
	private float spawnTimer = 0.0f;
	private bool nextIsWall = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spawnTimer <= 0.0f)
		{
			spawner.transform.position = new Vector3(spawner.transform.position.x + 2.0f, 2.0f, spawner.transform.position.z);
			int rand;
			if (!nextIsWall)
				rand = Random.Range(0, 14);
			else
				rand = Random.Range(0, 9);
			switch (rand)
			{
				case 0:
				case 7:
				case 4:
					Instantiate(wall1, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = false;
					break;
				case 1:
				case 8:
				case 5:
					Instantiate(wall2, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = false;
					break;
				case 2:
				case 3:
				case 6:
					Instantiate(wall3, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = false;
					break;
				case 9:
					Instantiate(door, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = true;
					break;
				case 10:
					Instantiate(door2, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = true;
					break;
				case 11:
					Instantiate(window1, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = true;
					break;
				case 12:
				case 13:
					Instantiate(alley, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsWall = true;
					break;
			}
			Vector3 pos = new Vector3(spawner.transform.position.x, spawner.transform.position.y-5.34f, spawner.transform.position.z);
			Instantiate(road, pos, Quaternion.Euler(0,0,0));
			spawnTimer = 0.1f;
		} else
			spawnTimer -= Time.deltaTime;	
	}
}
