using UnityEngine;
using System.Collections;

public class MiniGameEndChecker : MonoBehaviour {

	public GameObject strike, check;
	private bool objCreated;
	private float endTimer;

	// Use this for initialization
	void Start () {
		objCreated = false;
		endTimer = 2.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Global.GamePlaying && !objCreated)
		{
			if (Global.GameResult)
				Instantiate(check);
			else
				Instantiate(strike);
			objCreated = true;
		} else if (objCreated)
		{
			if (endTimer <= 0.0f)
			{
				Application.LoadLevel("Interrogation");
			} else
				endTimer -= Time.deltaTime;
		}
	}
}
