using UnityEngine;
using System.Collections;

public class Driver_Obstacle : MonoBehaviour 
{
	public const float SPEED = 15.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED * Time.deltaTime, this.transform.position.z);	
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "Background End")
			Destroy(this);
	}
}
