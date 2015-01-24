using UnityEngine;
using System.Collections;

public class RunnerCameraScript : MonoBehaviour {

	public Transform player;

	void Update () 
	{
		transform.position = new Vector3(player.position.x + 6, 0, -10);
	
	}
}
