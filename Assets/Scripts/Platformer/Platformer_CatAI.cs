using UnityEngine;
using System.Collections;

public class Platformer_CatAI : MonoBehaviour {

	private float SPEED = 18.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.GamePlaying)
		{
			this.transform.position += new Vector3(SPEED * Time.deltaTime, 0, 0);
		}
	}
}
