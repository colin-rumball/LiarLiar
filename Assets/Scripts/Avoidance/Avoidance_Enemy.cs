using UnityEngine;
using System.Collections;

public class Avoidance_Enemy : MonoBehaviour {

	public GameObject target;
	
	public const float SPEED = 2f;

	// Use this for initialization
	void Start () 
	{
		if (Random.Range(0, 2) == 1)
			target = GameObject.Find("Player1");
		else
			target = GameObject.Find("Player2");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = SPEED * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
}
