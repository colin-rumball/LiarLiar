using UnityEngine;
using System.Collections;

public class Die3D : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (Global.GamePlaying)
		{
			if(other.tag == "Player" ||other.tag == "Player2")
			{
				Global.GameResult = false;
				Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			}
		}
	}
}
