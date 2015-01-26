using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Introduction : MonoBehaviour 
{
	public bool GotoInterrogation = false;
	// Update is called once per frame
	void Update () {

		if (GotoInterrogation) {
						Application.LoadLevel ("Interrogation");
				}
		
	}

}
