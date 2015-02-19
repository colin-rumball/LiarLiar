using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instruction : MonoBehaviour 
{
	public Text instructionText, WASDText, CtrlText, TabText, ArrowKeysText;
	public Image WASDImage, CtrlImage, TabImage, ArrowKeysImage;
	private float timer = 3.0f;

	void Start () 
	{
		instructionText.text = Global.LevelInstruction;

		switch(Global.LevelToLoad-5)
		{
		case 0:
			WASDImage.gameObject.SetActive(true);
			WASDText.gameObject.SetActive(true);
			WASDText.text = "Move and Jump";

			ArrowKeysImage.gameObject.SetActive(true);
			ArrowKeysText.gameObject.SetActive(true);
			ArrowKeysText.text = "Move and Jump";
			break;
		case 1:
			WASDImage.gameObject.SetActive(true);
			WASDText.gameObject.SetActive(true);
			WASDText.text = "Jump";

			ArrowKeysImage.gameObject.SetActive(true);
			ArrowKeysText.gameObject.SetActive(true);
			ArrowKeysText.text = "Jump";
			break;
		case 2:
			WASDImage.gameObject.SetActive(true);
			WASDText.gameObject.SetActive(true);
			WASDText.text = "Change Lane";

			ArrowKeysImage.gameObject.SetActive(true);
			ArrowKeysText.gameObject.SetActive(true);
			ArrowKeysText.text = "Change Lane";
			break;
		case 4:
			WASDImage.gameObject.SetActive(true);
			WASDText.gameObject.SetActive(true);
			WASDText.text = "Move";

			ArrowKeysImage.gameObject.SetActive(true);
			ArrowKeysText.gameObject.SetActive(true);
			ArrowKeysText.text = "Move";
			break;
		case 8:
			TabImage.gameObject.SetActive(true);
			TabText.gameObject.SetActive(true);
			TabText.text = "Punch";

			CtrlImage.gameObject.SetActive(true);
			CtrlText.gameObject.SetActive(true);
			CtrlText.text = "Punch";
			break;
		}
	}

	void Update () 
	{
		if (timer <= 0.0f)
		{
			Application.LoadLevel(Global.LevelToLoad);
		} else
			timer -= Time.deltaTime;
	}
}
