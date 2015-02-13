using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	HUDScript hud;

	void Start()
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"||other.tag == "Player2")
		{
			Global.GameCounter++;
			Destroy (this.gameObject);
		}
	}
}
