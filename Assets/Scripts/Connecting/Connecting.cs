using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(NetworkManager))]

public class Connecting : MonoBehaviour 
{
	public Text text;
	private NetworkManager networkManager;

	// Use this for initialization
	void Start () {
		networkManager = this.GetComponent<NetworkManager>();
		networkManager.Connect();
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (PhotonNetwork.room != null)
		{
			if (PhotonNetwork.room.playerCount == 2 && PhotonNetwork.isMasterClient)
			{
				Application.LoadLevel("Introduction");
			} else
			{
				text.text = "WAITING FOR ADDITIONAL PLAYER.";
			}
		} else
		{
			text.text = "CONNECTING";
		}
	}
}
