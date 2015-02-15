using UnityEngine;
using System.Collections;

public class Platform_Camera : MonoBehaviour {

	public const float SPEED = 5.0f;
	private float timer = 8.0f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			float step = SPEED * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, 
			                                         new Vector3(108.0f, this.transform.position.y, this.transform.position.z), 
			                                         step);
		}
	}
}
