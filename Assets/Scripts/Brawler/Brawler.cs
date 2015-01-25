using UnityEngine;
using System.Collections;

public class Brawler : MonoBehaviour {
	
	public GameObject enemy;
	private float spawnTimer = 0.8f;

	// Use this for initialization
	void Start () {
	
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
				Instantiate(enemy, pos, rot);
				spawnTimer = Random.Range(4, 12)/10.0f;
			}
	}
}
