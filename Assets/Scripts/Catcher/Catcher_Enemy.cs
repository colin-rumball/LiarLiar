using UnityEngine;
using System.Collections;

public class Catcher_Enemy : MonoBehaviour {

	private GameObject player1, player2;
	private const float SPEED = 2.0f;
	private Vector3 target;

	// Use this for initialization
	void Start () 
	{
		target = transform.position;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (Vector3.Distance(transform.position, player1.transform.position) < 6.0f || Vector3.Distance(transform.position, player2.transform.position) < 6.0f)
			{
				target = (transform.position - player1.transform.position) + (transform.position - player2.transform.position);

				Vector3 moveTo = Vector3.MoveTowards(transform.position, target+transform.position, SPEED * Time.deltaTime);
				if (moveTo.x > this.transform.position.x)
					this.transform.rotation = Quaternion.Euler(0,0,0);
				else
					this.transform.rotation = Quaternion.Euler(0,-180.0f,0);

				transform.position = moveTo;
			} else
			{
				target = transform.position;
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
		if (Global.GamePlaying)
		{
			if(other.tag == "Catcher-Object")
			{
				Destroy(this);
				Global.GameResult = true;
				Global.GamePlaying = false;
			}
		}
	}
}
