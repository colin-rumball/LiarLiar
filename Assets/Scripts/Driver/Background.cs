using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float SPEED = 15.0f;
	private bool stopping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED * Time.deltaTime, this.transform.position.z);

		if (stopping)
			SPEED -= SPEED * 0.1f;

		if (SPEED < 0.0f)
			SPEED = 0.0f;
	}

	public void startStopping()
	{
		stopping = true;
	}
	
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "Background End")
			this.transform.position = new Vector3(this.transform.position.x, 12.0f, this.transform.position.z);
	}
}
