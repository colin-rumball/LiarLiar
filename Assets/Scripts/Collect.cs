﻿using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	HUDScript hud;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"||other.tag == "Player2")
		{
			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(10);
			Destroy (this.gameObject);
		}
	}
}