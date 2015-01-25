using UnityEngine;
using System.Collections;

public class Catcher_Player : MonoBehaviour {

	public const float SPEED = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = Vector3.zero;
		if (tag == "Player") 
		{
			move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			transform.position += move * SPEED * Time.deltaTime;
		} else if (tag == "Player2") 
		{
			move = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);
			transform.position += move * SPEED * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider c)
	{

	}
}
