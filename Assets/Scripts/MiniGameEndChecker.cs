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
			{
				//PhotonNetwork.Instantiate("Check_Animation", Vector3.zero, Quaternion.Euler(0,0,0), 0);
				Instantiate(check);
			}
			else
			{
				//PhotonNetwork.Instantiate("Strike_Animation", Vector3.zero, Quaternion.Euler(0,0,0), 0);
				Instantiate(strike);
			}
			objCreated = true;
		} else if (objCreated)
		{
			if (endTimer <= 0.0f)
			{
				PhotonNetwork.LoadLevel("Interrogation");
			} else
				endTimer -= Time.deltaTime;
		}
	}
}
