using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" ||other.tag == "Player2")
	{
			Global.GameResult = false;
			Application.LoadLevel("Interrogation");
	}
	}

}
