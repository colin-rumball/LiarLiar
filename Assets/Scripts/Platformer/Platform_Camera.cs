using UnityEngine;
using System.Collections;

public class Platform_Camera : MonoBehaviour {
	public GameObject player1, player2;
	public Platformer_Background spawner;
	public const float SPEED = 5.0f;
	private float timer = 8.0f;

	public GameObject alien;

	// Use this for initialization
	void Start () 
	{
		string gameVar = PlayerPrefs.GetString("GameVariable");

		switch(gameVar)
		{
		case "Cat":
			break;
		case "Astronaut":
			spawner.setObs(alien);
			break;
		case "Bananas":
			break;
		case "Horror":
			break;
		case "Drunk":
			break;
		case "Ghost":
			break;
		case "Spy":
			break;
		case "Explosions":
			break;
		case "Mother":
			break;
		}
		spawner.setObs(alien);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timer <= 0.0f)
		{
			PlayerPrefs.SetString("Result", "Success");
			Application.LoadLevel("Interrogation");
		} else
		{
			timer -= Time.deltaTime;
		}
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
