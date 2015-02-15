using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Global.GamePlaying)
		{
			if(other.tag == "Player" ||other.tag == "Player2")
			{
				Destroy(this);
				Global.GameResult = false;
				Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			}
		}
	}

}
