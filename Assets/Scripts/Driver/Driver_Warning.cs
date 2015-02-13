using UnityEngine;
using System.Collections;

public class Driver_Warning : MonoBehaviour {

	//private float lifeTimer = 99.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (lifeTimer <= 0.0f)
		{
			des
		} else
			lifeTimer -= Time.deltaTime;*/
	}

	public void setLifeTime(float _t)
	{
		Destroy(this.gameObject, _t);
		//lifeTimer = _t;
	}
}
