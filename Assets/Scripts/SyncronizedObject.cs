using UnityEngine;
using System.Collections;

public class SyncronizedObject : MonoBehaviour 
{
	Vector3 realPosition = Vector3.zero;
	private Animator anim;
	private bool iOwn = false;
	// Use this for initialization
	void Start () {
		realPosition = transform.position;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!iOwn)
		{
			// Lerp between the current position and the position provided from the server.
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			if (anim != null)
			{
				anim.SetFloat("Speed", Mathf.Abs(transform.position.x-realPosition.x));
			}
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
			Vector3 pos = transform.localPosition;
			stream.Serialize(ref pos);

			Vector3 scale = transform.localScale;
			stream.Serialize(ref scale);
			//stream.SendNext(transform.position);
			//stream.SendNext(transform.rotation);
			//stream.SendNext(anim.speed);
			//stream.SendNext(myCharScript.currentAnimation);
		}
		// If receiving information.
		else 
		{
			Vector3 pos = Vector3.zero;
			stream.Serialize(ref pos);  // pos gets filled-in. must be used somewhere
			realPosition = pos;

			Vector3 scale = transform.localScale;
			stream.Serialize(ref scale);
			transform.localScale = scale;
			// If this character has not spawned yet then set it's name and position.
			/*if (!spawned)
			{
				this.GetComponentInChildren<TextMesh>().text = this.GetComponent<PhotonView>().owner.name;
				transform.position = (Vector3) stream.ReceiveNext();
				spawned = true;
			} else*/
			//{
				//realPosition = (Vector3) stream.ReceiveNext();
			//}
			//transform.rotation = (Quaternion) stream.ReceiveNext();
			//anim.speed = (float) stream.ReceiveNext();
			//anim.Play((string) stream.ReceiveNext());
		}
	}

	public void setIOwn(bool b)
	{
		iOwn = b;
	}
}
