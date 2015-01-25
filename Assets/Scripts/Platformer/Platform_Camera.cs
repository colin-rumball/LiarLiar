using UnityEngine;
using System.Collections;

public class Platform_Camera : MonoBehaviour {
	public GameObject player1, player2;
	public const float SPEED = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = SPEED * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, 
		                                         new Vector3(108.0f, this.transform.position.y, this.transform.position.z), 
		                                         step);
		/*if (player1.transform.position.x > this.transform.position.x)
		{
			transform.position = Vector3.MoveTowards(transform.position, 
			                                         new Vector3(player1.transform.position.x, this.transform.position.y, this.transform.position.z), 
			                                         step);
		} else if (player2.transform.position.x > this.transform.position.x)
		{
			transform.position = Vector3.MoveTowards(transform.position, 
			                                         new Vector3(player2.transform.position.x, this.transform.position.y, this.transform.position.z), 
			                                         step);
		}*/
	}
}
