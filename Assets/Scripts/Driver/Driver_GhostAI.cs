using UnityEngine;
using System.Collections;

public class Driver_GhostAI : MonoBehaviour {

	public const float SPEED = 3.0f;
	private bool goingRight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (goingRight)
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, 
				                            new Vector3(this.transform.position.x+5.0f, this.transform.position.y, 
				            				this.transform.position.z), SPEED * Time.deltaTime);
			} else
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, 
				                                              new Vector3(this.transform.position.x-5.0f, this.transform.position.y, 
				            this.transform.position.z), SPEED * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Boundary")
		{
			goingRight = !goingRight;
		}
	}

	public void setGoingRight(bool _b)
	{
		goingRight = _b;
	}
}
