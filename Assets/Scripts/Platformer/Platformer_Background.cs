using UnityEngine;
using System.Collections;

public class Platformer_Background : MonoBehaviour {
	public GameObject plain, box, alley, window, background, spawner;
	private float spawnTimer = 0.0f;
	private bool nextIsPlain = false;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++)
		{
			int rand;
			if (!nextIsPlain)
				rand = Random.Range(0, 9);
			else
				rand = Random.Range(0, 6);
			switch (rand)
			{
			case 0:
			case 2:
			case 4:
				Instantiate(plain, spawner.transform.position, Quaternion.Euler(0,0,0));
				nextIsPlain = false;
				break;
			case 1:
			case 3:
			case 5:
				Instantiate(window, spawner.transform.position, Quaternion.Euler(0,0,0));
				nextIsPlain = false;
				break;
			case 6:
				Instantiate(box, spawner.transform.position, Quaternion.Euler(0,0,0));
				nextIsPlain = true;
				break;
			case 7:
			case 8:
				Instantiate(alley, spawner.transform.position, Quaternion.Euler(0,0,0));
				nextIsPlain = true;
				break;
			}
			//Vector3 pos = new Vector3(spawner.transform.position.x, spawner.transform.position.y-5.34f, spawner.transform.position.z);
			//Instantiate(road, pos, Quaternion.Euler(0,0,0));
			spawner.transform.position = new Vector3(spawner.transform.position.x + 6.36f, -2.7f, spawner.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
