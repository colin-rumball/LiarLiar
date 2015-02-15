using UnityEngine;
using System.Collections;

public class Avoidance_Player1 : MonoBehaviour {

	public const int SPEED = 3;
	private Animator anim;
	private bool facingRight = true;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		anim.SetBool("Ground", true);
		if (tag == "Player") 
			Flip();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Global.GamePlaying)
		{
			if (tag == "Player") 
			{
				if (Input.GetKey(KeyCode.A))
				{
					this.transform.position = new Vector3(this.transform.position.x- SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
					if (facingRight)
						Flip();
				} else if (Input.GetKey(KeyCode.D))
				{
					this.transform.position = new Vector3(this.transform.position.x+ SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
					if (!facingRight)
						Flip();
				} else
				{
					anim.SetFloat("Speed", 0.0f);
				}
				if (Input.GetKey(KeyCode.S))
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED*Time.deltaTime, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
				} else if (Input.GetKey(KeyCode.W))
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + SPEED*Time.deltaTime, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
				}
			} else if (tag == "Player2") 
			{
				if (Input.GetKey(KeyCode.LeftArrow))
				{
					this.transform.position = new Vector3(this.transform.position.x- SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
					if (facingRight)
						Flip();
				} else if (Input.GetKey(KeyCode.RightArrow))
				{
					this.transform.position = new Vector3(this.transform.position.x+ SPEED*Time.deltaTime, this.transform.position.y, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
					if (!facingRight)
						Flip();
				} else
				{
					anim.SetFloat("Speed", 0.0f);
				}
				if (Input.GetKey(KeyCode.DownArrow))
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - SPEED*Time.deltaTime, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
				} else if (Input.GetKey(KeyCode.UpArrow))
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + SPEED*Time.deltaTime, this.transform.position.z);
					anim.SetFloat("Speed", SPEED);
				}
			}
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
