using UnityEngine;
using System.Collections;
	
	public class DriverUserControl : MonoBehaviour {
		
		float speed = 4.0f;
		
		void Update() {
		if (tag == "Player") {
			var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			transform.position += move * speed * Time.deltaTime;
		}
		if (tag == "Player2") {
			var move = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);
			transform.position += move * speed * Time.deltaTime;
		}
		}
	}

