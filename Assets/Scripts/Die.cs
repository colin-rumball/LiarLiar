using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" ||other.tag == "Player2")
	{
		Debug.Break ();
	}
	}

}
