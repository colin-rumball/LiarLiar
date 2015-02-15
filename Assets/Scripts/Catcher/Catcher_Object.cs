using UnityEngine;
using System.Collections;

public class Catcher_Object : MonoBehaviour {

	private const float SPEED = 1.0f;
	private GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, SPEED * Time.deltaTime);
		}
	}

	void attachTo(GameObject obj)
	{
		target = obj;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Global.GamePlaying)
		{
			if(other.tag == "Player" || other.tag == "Player2")
			{
				attachTo(other.gameObject);
			}
		}
	}
}
