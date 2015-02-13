using UnityEngine;
using System.Collections;

public class Driver_SpyAI : MonoBehaviour {

	public const float SPEED = 3.0f;
	private Vector3 playerLastPosition;
	private float directionTimer = 0.0f;
	private GameObject player1, player2;

	// Update is called once per frame
	void Update () 
	{
		if (directionTimer <= 0.0f)
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

		transform.position = newPos;
	}

	public void setPlayers(GameObject p1, GameObject p2)
	{
		player1 = p1;
		player2 = p2;
	}
}
