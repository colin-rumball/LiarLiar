using UnityEngine;
using System.Collections;

public class RunnerCameraScript : MonoBehaviour {

	public Transform player;
	private float distance = 6.0f;

	void Update () 
	{
		if (Global.GamePlaying)
		{
			transform.position = new Vector3(player.position.x + distance, 0, -10);
		}
	}

	public void setDistance(float f)
	{
		distance = f;
	}
}
