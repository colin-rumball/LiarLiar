using UnityEngine;
using System.Collections;

public class Die3D : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" ||other.tag == "Player2")
		{
			Global.GameResult = false;
			Application.LoadLevel("Interrogation");
		}
	}
}
