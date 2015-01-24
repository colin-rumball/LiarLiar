using UnityEngine;
using System.Collections;

public class QTE_Input : MonoBehaviour 
{

	public KeyCode[] expectedInput;
	private int currentIndex = 0;

	// Use this for initialization
	void Start () 
	{
		fillArray("ADDFGT");
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(expectedInput[currentIndex]);
		if (Input.GetKeyDown(expectedInput[currentIndex]))
		{
			if (currentIndex < expectedInput.Length-1)
				currentIndex++;
		}
	}

	void fillArray(string str)
	{
		char[] charArr = str.ToCharArray();
		expectedInput = new KeyCode[charArr.Length];
		for (int i = 0; i < charArr.Length; i++)
		{
			expectedInput[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), charArr[i].ToString());
		}
	}
}
