using UnityEngine;
using System.Collections;

public class Brawler_Enemy : MonoBehaviour {

	public const float SPEED = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = SPEED * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, -1.45f, -1.0f), step);
	}
}
