using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Introduction : MonoBehaviour 
{
	public Text line1, line2;
	float timer = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 2.0f && line1.text == "")
		{
			line1.text = "Hey!";
		} else if (timer <= 0.0f)
		{
			line2.text = "Stop!";
		}
		
		
	}
}
