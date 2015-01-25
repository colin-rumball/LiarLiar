using UnityEngine;
using System.Collections;

public class Brawler_Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (tag == "Player") 
		{
			if (Input.GetButton("Fire1"))
			{
				Debug.DrawRay(transform.position, transform.right, Color.black);
				RaycastHit hitInfo = new RaycastHit();
				bool hit = Physics.Raycast(transform.position, transform.right, out hitInfo);
				if (hit) 
				{
					Debug.Log("Hit " + hitInfo.transform.gameObject.name);
					if (hitInfo.transform.gameObject.tag == "Brawler-Punchable")
					{
						Debug.Log ("It's working!");
					} else {
						Debug.Log ("nopz");
					}
				} else {
					Debug.Log("No hit");
				}
			}
		} else if (tag == "Player2") 
		{
			if (Input.GetButton("Fire2"))
			{
				Debug.DrawRay(transform.position, transform.right, Color.black);
				RaycastHit hitInfo = new RaycastHit();
				bool hit = Physics.Raycast(transform.position, transform.right, out hitInfo);
				if (hit) 
				{
					Debug.Log("Hit " + hitInfo.transform.gameObject.name);
					if (hitInfo.transform.gameObject.tag == "Brawler-Punchable")
					{
						Debug.Log ("It's working!");
					} else {
						Debug.Log ("nopz");
					}
				} else {
					Debug.Log("No hit");
				}
			}
		}
	}
}
