using UnityEngine;
using System.Collections;

public class FPS_Gun : MonoBehaviour {

	public const int SPEED = 5;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-0.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Debug.DrawRay(transform.position, transform.forward, Color.green);
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "FPS-Shootable")
				{
					Debug.Log ("It's working!");
				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
		}

		if (Input.GetKey(KeyCode.A))
		{
			this.transform.position = new Vector3(this.transform.position.x- SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
		} else if (Input.GetKey(KeyCode.D))
		           {
			this.transform.position = new Vector3(this.transform.position.x+ SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
		} else if (Input.GetKey(KeyCode.S))
		           {
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED*Time.deltaTime, this.transform.position.z);
		} else if (Input.GetKey(KeyCode.W))
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + SPEED*Time.deltaTime, this.transform.position.z);
		}
	}
}
