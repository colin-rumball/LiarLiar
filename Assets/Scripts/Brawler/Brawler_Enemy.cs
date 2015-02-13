using UnityEngine;
using System.Collections;

public class Brawler_Enemy : MonoBehaviour {

	public const float SPEED = 5.0f;
	private bool roll;

	// Use this for initialization
	void Start () {
		roll = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = SPEED * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, -1.45f, -1.0f), step);

		if (roll)
		{
			if (transform.position.x < 0.0f)
			{
				transform.Rotate(new Vector3(0, 0, 5.0f));
			} else
			{
				transform.Rotate(new Vector3(0, 0, -5.0f));
			}
		}

	}

	public void setToRoll()
	{
		roll = true;;
	}
}
