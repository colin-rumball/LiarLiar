using UnityEngine;
using System.Collections;

public class Die3D : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" ||other.tag == "Player2")
		{
			PlayerPrefs.SetInt("Result", 0);
			Application.LoadLevel("Interrogation");
		}
	}
}
