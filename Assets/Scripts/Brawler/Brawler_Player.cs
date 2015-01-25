using UnityEngine;
using System.Collections;

public class Brawler_Player : MonoBehaviour {

	private float punchTimer = 0.0f;
	private Animator anim; // Reference to the player's animator component.
	private bool punched = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
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
		} else if (punched && punchTimer <= 0.35f)
		{
			anim.SetBool("Punching", false);
			punched = false;
		} else
			punchTimer -= Time.deltaTime;
	}
	
	void punch()
	{
		anim.SetBool("Punching", true);
		punched = true;
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
