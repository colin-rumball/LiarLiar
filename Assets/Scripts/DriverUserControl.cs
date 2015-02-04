using UnityEngine;
using System.Collections;
	
public class DriverUserControl : MonoBehaviour 
{
	float speed = 4.0f;

	private float swerveTimer = 0.6f;
	
	void Update() 
	{
		Vector3 move = Vector3.zero;

		if (swerveTimer > 0.0f)
		{
			float xValue = Random.Range(1, 10)/10.0f;
			if (Mathf.FloorToInt(swerveTimer * 10.0f) % 2 == 0)
				xValue *= -1;
			move = new Vector3(xValue, 0.0f, 0.0f);
			swerveTimer -= Time.deltaTime;
		}

		if (tag == "Player") 
		{
			move += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		} else if (tag == "Player2") 
		{
			move += new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);
		}
		transform.position += move * speed * Time.deltaTime;

		if (move.x > 0.0f)
		{
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -move.x*5.0f);
		} else if (move.x < 0.0f)
		{
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -move.x*5.0f);
		} else
		{
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		}
	}
}

