using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Introduction : MonoBehaviour 
{
	public bool GotoInterrogation = false;
	public bool stage1 = false, stage2 = false, stage3 = false, stage1Done = false, stage2Done = false, stage3Done = false;

	public GameObject copBubble, playersBubble;
	public Image background;
	public Sprite bg1, bg2, bg3;
	
	private float endingTimer = 2.0f;
	private float beginningTimer = 2.0f;

	void Start()
	{
	}
	// Update is called once per frame
	void Update () 
	{
		if (GotoInterrogation) 
		{
			Application.LoadLevel ("Interrogation");
		}

		if (stage2 && !stage2Done)
		{
			goToStage2();
			stage2Done = true;
		}
		if (stage3 && !stage3Done)
		{
			goToStage3();
			stage3Done = true;
		}
		
	}

	public void goToStage2()
	{
		background.sprite = bg2;
		stage2 = false;
	}

	public void goToStage3()
	{
		background.sprite = bg3;
		//copBubble.GetComponentInChildren<Text>().text = "Explain yourselves!";
		stage3 = false;
	}

}
