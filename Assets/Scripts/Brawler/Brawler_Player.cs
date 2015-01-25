using UnityEngine;
using System.Collections;

public class Brawler_Player : MonoBehaviour {

	private float punchTimer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (punchTimer <= 0.0f)
		{
			if (tag == "Player") 
			{
				if (Input.GetButton("Fire1"))
				{
					punch();
				}
			} else if (tag == "Player2") 
			{
				if (Input.GetButton("Fire2"))
				{
					punch();
				}
			}
		} else
			punchTimer -= Time.deltaTime;
	}
	
	void punch()
	{
		Debug.DrawRay(transform.position, transform.right, Color.black);
		RaycastHit hitInfo = new RaycastHit();
		bool hit = Physics.Raycast(transform.position, transform.right, out hitInfo, 1);
		if (hit) 
		{
			Debug.Log("Hit " + hitInfo.transform.gameObject.name);
			if (hitInfo.transform.gameObject.tag == "Brawler-Punchable")
			{
				Destroy(hitInfo.transform.gameObject);
				Debug.Log ("It's working!");
			} else {
				//Debug.Log ("nopz");
			}
		} else {
			//Debug.Log("No hit");
		}
		punchTimer = 0.4f;
	}
	void OnTriggerEnter(Collider c)
	{
		print("asd");
	}
}
