using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HowToPlay : MonoBehaviour 
{
	public GameObject nextButton, prevButton;
	public Text pageNumberText, mainTextField;
	public Image mainImage;
	public Sprite[] mainImages;

	private int page;
	private string[] textFields = 
		{"You two are criminals that have been caught by the police while committing a crime. Your only way out of this is to lie through your teeth.",
		"Together you will create a lie to tell the police what you were doing. Each of you will select a word to contribute and the lie will be born.",
		"Once your selections have been made you will recount the lie by playing it, no matter how ridiculous it is, otherwise the police will not believe you. Three strikes and it's jail for you."};

	void Start () 
	{
		page = 1;	
		setHowToContent();
	}


	void Update () 
	{
	
	}

	public void ReturnToMainMenu()
	{
		Application.LoadLevel("MainMenu");
	}

	public void NextPage()
	{
		page++;

		if (page == 3)
		{
			nextButton.SetActive(false);
		}
		prevButton.SetActive(true);
		setHowToContent();
	}

	public void PrevPage()
	{
		page--;

		if (page == 1)
		{
			prevButton.SetActive(false);
		}
		nextButton.SetActive(true);
		setHowToContent();
	}

	private void setHowToContent()
	{
		mainImage.sprite = mainImages[page-1];
		mainTextField.text = textFields[page-1];
		pageNumberText.text = page.ToString()+" / 3";
	}
}
