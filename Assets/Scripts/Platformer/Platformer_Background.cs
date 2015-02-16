using UnityEngine;
using System.Collections;

public class Platformer_Background : MonoBehaviour {
	public GameObject plain, box, alley, window, spawner;
	private GameObject obs;
	private float spawnTimer = 0.0f;
	private bool nextIsPlain = false;
	private bool init = false;
	
	// Use this for initialization
	void Start () {

	}

	public void setObs(GameObject _obj)
	{
		obs = _obj;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying && (PhotonNetwork.isMasterClient || PhotonNetwork.offlineMode))
		{
			if (obs != null && !init)
			{
				for (int i = 0; i < 20; i++)
				{
					int rand;
					if (!nextIsPlain)
						rand = Random.Range(0, 9);
					else
						rand = Random.Range(0, 6);
					switch (rand)
					{
					case 0:
					case 2:
					case 4:
						if (Mathf.FloorToInt(Random.Range(0, 3)) == 2)
							this.GetComponent<PhotonView>().RPC("createObs", PhotonTargets.All, new Vector3(spawner.transform.position.x, 0.0f, -1));
						this.GetComponent<PhotonView>().RPC("createPlain", PhotonTargets.All, spawner.transform.position);
						nextIsPlain = false;
						break;
					case 1:
					case 3:
					case 5:
						if (Mathf.FloorToInt(Random.Range(0, 3)) == 2)
							this.GetComponent<PhotonView>().RPC("createObs", PhotonTargets.All, new Vector3(spawner.transform.position.x, 0.0f, -1));
						this.GetComponent<PhotonView>().RPC("createWindow", PhotonTargets.All, spawner.transform.position);
						nextIsPlain = false;
						break;
					case 6:
						this.GetComponent<PhotonView>().RPC("createPlain", PhotonTargets.All, spawner.transform.position);
						nextIsPlain = true;
						break;
					case 7:
					case 8:
						this.GetComponent<PhotonView>().RPC("createAlley", PhotonTargets.All, spawner.transform.position);
						nextIsPlain = true;
						break;
					}
					//Vector3 pos = new Vector3(spawner.transform.position.x, spawner.transform.position.y-5.34f, spawner.transform.position.z);
					//Instantiate(road, pos, Quaternion.Euler(0,0,0));
					spawner.transform.position = new Vector3(spawner.transform.position.x + 6.36f, -2.7f, spawner.transform.position.z);
				}
				init = true;
			}
		}
	}

	[RPC]
	public void createPlain(Vector3 pos)
	{
		Instantiate(plain, pos, Quaternion.Euler(0,0,0));
	}

	[RPC]
	public void createAlley(Vector3 pos)
	{
		Instantiate(alley, pos, Quaternion.Euler(0,0,0));
	}

	[RPC]
	public void createWindow(Vector3 pos)
	{
		Instantiate(window, pos, Quaternion.Euler(0,0,0));
	}

	[RPC]
	public void createObs(Vector3 pos)
	{
		Instantiate(obs, pos, Quaternion.Euler(0,0,0));
	}
}
