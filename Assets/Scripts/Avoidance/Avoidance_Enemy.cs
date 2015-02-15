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
		if (Global.GamePlaying)
		{
			float step = SPEED * Time.deltaTime;
			Vector3 moveTo = Vector3.MoveTowards(transform.position, target.transform.position, step);
			if (moveTo.x > this.transform.position.x)
				this.transform.rotation = Quaternion.Euler(0,0,0);
			else
				this.transform.rotation = Quaternion.Euler(0,-180.0f,0);
			transform.position = moveTo;
		}
	}
}
