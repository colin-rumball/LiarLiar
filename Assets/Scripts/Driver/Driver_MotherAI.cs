using UnityEngine;
using System.Collections;

public class Driver_MotherAI : MonoBehaviour 
{
	public const float SPEED = 0.8f;
	private float gameCompleteTimer, initialMovementTimer;
	private bool moving = false, initialMovement;
	private Vector3 playerPos, moveToLocation;
	private GameObject player1, player2;

	// Use this for initialization
	void Start () 
	{
		moveToLocation = new Vector3(8.52f, 0.69f, -1.0f);
		initialMovementTimer = 12.5f;
		initialMovement = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (initialMovement)
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, moveToLocation, SPEED * Time.deltaTime);
				if (initialMovementTimer <= 0.0f)
				{
					initialMovement = false;
				} else
					initialMovementTimer -= Time.deltaTime;
			} else if (moving)
			{
				if (gameCompleteTimer <= 0.0f)
				{
					//Application.LoadLevel("Interrogation");
					Global.GamePlaying = false;
				} else
					gameCompleteTimer -= Time.deltaTime;

				this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, SPEED * Time.deltaTime);
			}
		}
	}

	public void setPlayers(GameObject p1, GameObject p2)
	{
		player1 = p1;
		player2 = p2;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" ||other.tag == "Player2")
		{
			moving = true;
			initialMovement = false;
			gameCompleteTimer = 2.0f;
			playerPos = other.transform.position;
			player1.transform.rotation = Quaternion.Euler(0,0,0);
			player2.transform.rotation = Quaternion.Euler(0,0,0);
			player1.GetComponent<DriverUserControl>().enabled = false;
			player2.GetComponent<DriverUserControl>().enabled = false;
		}
	}


}
