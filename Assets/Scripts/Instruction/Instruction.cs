using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instruction : MonoBehaviour {
	public Text text;
	private float timer = 2.5f;

	// Use this for initialization
	void Start () 
	{
		text.text = Global.LevelInstruction;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0.0f)
		{
			Application.LoadLevel(Global.LevelToLoad);
		} else
			timer -= Time.deltaTime;
	}
}
