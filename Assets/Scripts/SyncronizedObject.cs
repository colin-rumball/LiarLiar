using UnityEngine;
using System.Collections;

public class SyncronizedObject : MonoBehaviour 
{
	Vector3 realPosition = Vector3.zero;
	public bool iOwn;
	// Use this for initialization
	void Start () {
		realPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!iOwn)
		{
			// Lerp between the current position and the position provided from the server.
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
		}
	}

	//--------------------------------------------------------------
	/// Called every time information is sent or recieved
	//--------------------------------------------------------------
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		// If sending information
		if (stream.isWriting) 
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			//stream.SendNext(anim.speed);
			//stream.SendNext(myCharScript.currentAnimation);
		}
		// If receiving information.
		else 
		{
			// If this character has not spawned yet then set it's name and position.
			/*if (!spawned)
			{
				this.GetComponentInChildren<TextMesh>().text = this.GetComponent<PhotonView>().owner.name;
				transform.position = (Vector3) stream.ReceiveNext();
				spawned = true;
			} else*/
			{
				realPosition = (Vector3) stream.ReceiveNext();
			}
			transform.rotation = (Quaternion) stream.ReceiveNext();
			//anim.speed = (float) stream.ReceiveNext();
			//anim.Play((string) stream.ReceiveNext());
		}
	}
}
