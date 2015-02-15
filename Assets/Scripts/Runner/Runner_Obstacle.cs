using UnityEngine;
using System.Collections;

public class Runner_Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		BoxCollider2D[] boxes = this.GetComponents<BoxCollider2D>();
		foreach(BoxCollider2D box in boxes)
		{
			if (!box.isTrigger)
			{
				box.GetComponent<Rigidbody2D>().isKinematic = true;
				Destroy(box);
			}
		}
	}
}
