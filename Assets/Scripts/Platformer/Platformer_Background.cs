using UnityEngine;
using System.Collections;

public class Platformer_Background : MonoBehaviour {
	public GameObject plain, box, alley, window, spawner;
	private GameObject obs;
	private float spawnTimer = 0.0f;
	private bool nextIsPlain = false;
	private bool init = false;
	
	// Use this for initialization
	void Start () {

	}

	public void setObs(GameObject _obj)
	{
		obs = _obj;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (obs != null && !init)
		{
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
					if (Mathf.FloorToInt(Random.Range(0, 4)) == 3)
						Instantiate(obs, new Vector3(spawner.transform.position.x, 0.0f, -1), Quaternion.Euler(0,0,0));
					Instantiate(plain, spawner.transform.position, Quaternion.Euler(0,0,0));
					nextIsPlain = false;
					break;
				case 1:
				case 3:
				case 5:
					if (Mathf.FloorToInt(Random.Range(0, 4)) == 3)
						Instantiate(obs, new Vector3(spawner.transform.position.x, 0.0f, -1), Quaternion.Euler(0,0,0));
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
			init = true;
		}
	}
}
