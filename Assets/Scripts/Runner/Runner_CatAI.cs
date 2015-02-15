using UnityEngine;
using System.Collections;

public class Runner_CatAI : MonoBehaviour {

	private const float SPEED = 1.6f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
			this.transform.position -= new Vector3(SPEED * Time.deltaTime, 0.0f, 0.0f);
	}
}
