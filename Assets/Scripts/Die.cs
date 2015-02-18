using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	private bool alive = true;

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Global.GamePlaying && alive)
		{
			if(other.tag == "Player" ||other.tag == "Player2")
			{
				this.GetComponent<PhotonView>().RPC("miniGameOver", PhotonTargets.All, null);
				alive = false;
				//Global.GameResult = false;
				//Global.GamePlaying = false;
				//Application.LoadLevel("Interrogation");
			}
		}
	}

	[RPC]
	public void miniGameOver()
	{
		Global.GameResult = false;
		Global.GamePlaying = false;
	}

}
