using UnityEngine;
using System.Collections;
	
	public class DriverUserControl : MonoBehaviour {
		
		float speed = 4.0f;
		
		void Update() 
		{
			Vector3 move = Vector3.zero;
			if (tag == "Player") 
			{
				move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
				transform.position += move * speed * Time.deltaTime;
			} else if (tag == "Player2") 
			{
				move = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);
				transform.position += move * speed * Time.deltaTime;
			}
			if (move.x > 0.0f)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -5.0f);
			} else if (move.x < 0.0f)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 5.0f);
			} else
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}
		}
	}

