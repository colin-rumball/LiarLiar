using UnityEngine;
using System.Collections;

public class Platformer_Obstacle : MonoBehaviour {

	private bool boxRemoved = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!boxRemoved)
		{
			BoxCollider2D[] boxes = this.GetComponents<BoxCollider2D>();
			foreach(BoxCollider2D box in boxes)
			{
				if (!box.isTrigger)
				{
					box.GetComponent<Rigidbody2D>().gravityScale = 0;
					box.GetComponent<Rigidbody2D>().isKinematic = true;
					Destroy(box);
					boxRemoved = true;
				}
			}
		}
	}
}
