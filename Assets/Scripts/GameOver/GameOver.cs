using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	public Text gamesWon;
	private NetworkManager m_networkManager;

	// Use this for initialization
	void Start ()
	{
		gamesWon.text = Global.GamesWon.ToString();;
		m_networkManager = this.GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnToMainMenu()
	{
		m_networkManager.Disconnect();
		Application.LoadLevel("MainMenu");
	}
}
