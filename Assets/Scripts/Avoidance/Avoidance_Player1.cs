using UnityEngine;
using System.Collections;

public class Avoidance_Player1 : MonoBehaviour {

	public const int SPEED = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.A))
		{
			this.transform.position = new Vector3(this.transform.position.x- SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
		} else if (Input.GetKey(KeyCode.D))
		{
			this.transform.position = new Vector3(this.transform.position.x+ SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
		}
		if (Input.GetKey(KeyCode.S))
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED*Time.deltaTime, this.transform.position.z);
		} else if (Input.GetKey(KeyCode.W))
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + SPEED*Time.deltaTime, this.transform.position.z);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}
