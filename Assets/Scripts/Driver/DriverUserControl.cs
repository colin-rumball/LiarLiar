using UnityEngine;
using System.Collections;
	
public class DriverUserControl : MonoBehaviour 
{
	float speed = 7.0f;
	public int lane;
	public DriverUserControl otherPlayer;

	private float swerveTimer = 0.7f;
	private float timeUntilSwerve = 1.2f;
	private Vector3 moveToLocation;
	private int gameVariable;
	private bool swerving;

	void Start()
	{
		swerveTimer = Random.Range(1.0f, 12.0f)/10.0f;
		timeUntilSwerve = Random.Range(11.0f, 22.0f)/10.0f;
		moveToLocation = transform.position;
		swerving = false;
	}
	
	void Update() 
	{
		Vector3 move = Vector3.zero;

		switch (gameVariable)
		{
		case 4:
			if (timeUntilSwerve <= 0.0f && swerveTimer > 0.0f)
			{
				swerving = true;
				float xValue = Random.Range(1, 10)/10.0f;
				if (Mathf.FloorToInt(swerveTimer * 10.0f) % 2 == 0)
					xValue *= -1;
				move = new Vector3(xValue, 0.0f, 0.0f);
				swerveTimer -= Time.deltaTime/2;
			} else
			{
				if (timeUntilSwerve >= 0.0f)
					timeUntilSwerve -= Time.deltaTime;
				else if (swerveTimer <= 0.0f)
				{
					swerveTimer = Random.Range(1.0f, 12.0f)/10.0f;
					timeUntilSwerve = Random.Range(11.0f, 22.0f)/10.0f;
					swerving = false;
				}
			}
			break;
		}

		if (!swerving)
		{
			if (tag == "Player") 
			{
				//move += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
				//move += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
				if (Input.GetAxis("Horizontal") > 0.0f && lane < 5 && otherPlayer.getLane() != lane+1)
				{
					lane++;
					moveToLocation += new Vector3(2.2f, 0.0f, 0.0f);
					Input.ResetInputAxes();
				} else if (Input.GetAxis("Horizontal") < 0.0f && lane > 0 && otherPlayer.getLane() != lane-1)
				{
					lane--;
					moveToLocation -= new Vector3(2.2f, 0.0f, 0.0f);
					Input.ResetInputAxes();
				}
			} else if (tag == "Player2") 
			{
				//move += new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);
				//move += new Vector3(Input.GetAxis("Horizontal2"), 0, 0);
				if (Input.GetAxis("Horizontal2") > 0.0f && lane < 5 && otherPlayer.getLane() != lane+1)
				{
					lane++;
					moveToLocation += new Vector3(2.2f, 0.0f, 0.0f);
					Input.ResetInputAxes();
				} else if (Input.GetAxis("Horizontal2") < 0.0f && lane > 0 && otherPlayer.getLane() != lane-1)
				{
					lane--;
					moveToLocation -= new Vector3(2.2f, 0.0f, 0.0f);
					Input.ResetInputAxes();
				}
			}

			//transform.position += move * speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, moveToLocation, speed * Time.deltaTime);

			if (transform.position.x > moveToLocation.x)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 5.0f);
			} else if (moveToLocation.x > transform.position.x)
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -5.0f);
			} else
			{
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}
		} else
		{
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

	public void setGameVariable(int _var)
	{
		gameVariable = _var;
	}

	public int getLane()
	{
		return lane;
	}
}

