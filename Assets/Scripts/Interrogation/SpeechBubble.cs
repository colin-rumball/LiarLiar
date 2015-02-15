using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBubble : MonoBehaviour 
{
	//string storedText;
	//Text text;
	Animator anim;
	Image image;
	Text textObj;
	//float rate = 1.2f;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		image = this.GetComponent<Image>();
		textObj = this.GetComponentInChildren<Text>();
		if (anim != null)
			anim.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		image.enabled = true;
		textObj.enabled = true;
		/*if (this.transform.localScale.x >= 1.0f)
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
		}*/
	}

	public void reset()
	{
		anim.playbackTime = 0;
	}
	
	/*public void setText(string _text)
	{
		text = this.GetComponentInChildren<Text>();
		text.text = _text;
	}*/

}
