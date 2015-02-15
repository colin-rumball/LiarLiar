using UnityEngine;
using System.Collections;

public class Driver_SpyAI : MonoBehaviour {

	public const float SPEED = 6.0f;
	private int playerLastPosition = -1;
	private int lane = 2;
	private Vector3 moveToLocation;
	private float directionTimer = 0.0f;
	private float pursueTimer = 1.2f;
	private GameObject player1, player2;
	private bool attacking = false;

	void Start()
	{
		moveToLocation = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (playerLastPosition == -1)
			{
				if (Mathf.FloorToInt(Random.Range(0, 2)) == 1)
					playerLastPosition = player1.GetComponent<DriverUserControl>().getLane();
				else
					playerLastPosition = player2.GetComponent<DriverUserControl>().getLane();
			}

			if (attacking)
			{
				if (directionTimer <= 0.0f)
				{
					transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.5f, transform.position.z), SPEED * Time.deltaTime);
					if (directionTimer <= -1.0f)
					{
						attacking = false;
						pursueTimer = 1.2f;
						if (Mathf.FloorToInt(Random.Range(0, 2)) == 1)
							playerLastPosition = player1.GetComponent<DriverUserControl>().getLane();
						else
							playerLastPosition = player2.GetComponent<DriverUserControl>().getLane();
					}
				} else
				{
					transform.position = Vector3.MoveTowards(transform.position, transform.position+new Vector3(0, 10.0f,0), SPEED * Time.deltaTime);
				}
				directionTimer -= Time.deltaTime;
			} else
			{
				if (playerLastPosition > lane)
				{
					lane++;
					moveToLocation += new Vector3(2.2f, 0.0f, 0.0f);
				} else if (playerLastPosition < lane)
				{
					lane--;
					moveToLocation -= new Vector3(2.2f, 0.0f, 0.0f);
				}

				transform.position = Vector3.MoveTowards(transform.position, moveToLocation, SPEED * Time.deltaTime);

				if (pursueTimer <= 0.0f)
				{
					this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
					directionTimer = 1.0f;
					attacking = true;
				} else
					pursueTimer -= Time.deltaTime;

				if (transform.position.x > moveToLocation.x)
				{
					this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 5.0f);
				} else if (moveToLocation.x > transform.position.x)
				{
					this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -5.0f);
				} else
				{
					this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
				}
			}
			


			/*if (directionTimer <= 0.0f)
			{
				if (Mathf.FloorToInt(Random.Range(0, 2)) == 1)
					playerLastPosition = player1.transform.position;
				else
					playerLastPosition = player2.transform.position;
				directionTimer = 1.8f;
			} else
				directionTimer -= Time.deltaTime;

			Vector3 newPos = Vector3.MoveTowards(this.transform.position, playerLastPosition, SPEED * Time.deltaTime);

			if (newPos.x > this.transform.position.x)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -5.0f);
			} else if (newPos.x < this.transform.position.x)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 5.0f);
			} else
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}

			transform.position = newPos;*/
		}
	}

	public void setPlayers(GameObject p1, GameObject p2)
	{
		player1 = p1;
		player2 = p2;
	}
}
