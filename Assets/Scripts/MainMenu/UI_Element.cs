using UnityEngine;
using System.Collections;

public class UI_Element : MonoBehaviour {

	CanvasGroup group;
	public const float SPEED = 0.8f;
	private bool fading = false;
	
	// Use this for initialization
	void Start () {
		group = this.GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fading)
		{
			if (group.alpha > 0.0f)
			{
				group.alpha -= Time.deltaTime * SPEED;
			} else
			{
				Application.LoadLevel("Introduction");
			}
		}
	}
	
	public void fadeOut()
	{
		fading = true;
	}
}
