using UnityEngine;
using System.Collections;

public class Runner_Chaser : MonoBehaviour 
{
	public const float SPEED = 12.0f;

	private float timer, pursuitTimer;
	private bool pursuing;

	private int direction;
	private const int FORWARD = 1;
	private const int BACKWARD = 0;

	// Use this for initialization
	void Start () 
	{
		timer = 2.0f;
		pursuing = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (timer <= 0.0f)
			{
				if (pursuing)
				{
					if (direction == FORWARD)
					{
						this.transform.position = Vector3.MoveTowards(transform.position, transform.position+new Vector3(5,0,0), SPEED * Time.deltaTime);
					} else 
					{
						this.transform.position = Vector3.MoveTowards(transform.position, transform.position+new Vector3(-5,0,0), (SPEED*2.0f) * Time.deltaTime);
					}
				} else
				{
					pursuing = true;
					direction = FORWARD;
				}
			} else
				timer -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "ChaserRightCollider")
		{
			if (pursuing && direction == FORWARD)
			{
				direction = BACKWARD;
			}
		} else if (other.name == "ChaserLeftCollider")
		{
			if (pursuing && direction == BACKWARD)
			{
				pursuing = false;
				timer = 3.4f;
			}
		}
	}
}
