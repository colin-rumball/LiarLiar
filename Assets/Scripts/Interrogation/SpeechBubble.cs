using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBubble : MonoBehaviour 
{
	string storedText;
	Text text;
	float timer = 0.01f;
	float rate = 1.2f;
	// Use this for initialization
	void Start () {
		text = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.transform.localScale.x >= 1.0f)
		{
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				if (storedText.Length <= 0 && timer <= -2.5f)
				{
					Destroy(this.gameObject);
				} else if (storedText.Length > 0)
				{
					text.text = storedText;
					storedText = "";
					//text.text += storedText.Substring(0, 1);
					//storedText = storedText.Substring(1);
					//timer = 0.1f;
				}
			}
		} else
		{
			this.transform.localScale = new Vector3(this.transform.localScale.x + rate *Time.deltaTime, this.transform.localScale.x + rate *Time.deltaTime, 1.0f);
			if (this.transform.localScale.x > 1.0f)
				this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			rate += rate*0.1f;
		}
	}
	
	public void setStoredText(string _text)
	{
		storedText = _text;
	}
}
