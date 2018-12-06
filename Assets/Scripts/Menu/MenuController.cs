using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	public Image langButton;

	public Slider effectVolume;
	public Slider musicVolume;
	
	[SerializeField]
	private GameObject mainPanel;
	[SerializeField]
	private GameObject startPanel;
	[SerializeField]
	private GameObject optionsPanel;
	[SerializeField]
	private GameObject creditsPanel;

	// Use this for initialization
	void Start ()
	{		
		AudioManager.instance.PlaySong();
		effectVolume.value = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
		musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeMusicVolume(float n){
		GameManager.instance.musicVolume = n;
		PlayerPrefs.SetFloat("MusicVolume",n);
		PlayerPrefs.Save();
	}

	public void ChangeEffectsVolume(float n){
		GameManager.instance.effectVolume = n;
		PlayerPrefs.SetFloat("EffectsVolume",n);
		PlayerPrefs.Save();
	}

	public void ToggleLang(){
		GameLangManager.instance.NextCurrentLanguage();
		
		langButton.sprite = Resources.Load<Sprite>("flag_"+GameLangManager.instance.GetCurrentLanguage());

		this.GetComponent<MenuLangController>().RefreshMenuLang();
	}

	public void ChangePanel(string scene){
		AudioManager.instance.PlayAnswer1();
		switch(scene) {
			case "main":
				mainPanel.SetActive(true);
				startPanel.SetActive(false);
				optionsPanel.SetActive(false);
				creditsPanel.SetActive(false);
			break;
			case "start":
				mainPanel.SetActive(false);
				startPanel.SetActive(true);
				optionsPanel.SetActive(false);
				creditsPanel.SetActive(false);
			break;
			case "options":
				mainPanel.SetActive(false);
				startPanel.SetActive(false);
				optionsPanel.SetActive(true);
				creditsPanel.SetActive(false);
			break;
			case "credits":
				mainPanel.SetActive(false);
				startPanel.SetActive(false);
				optionsPanel.SetActive(false);
				creditsPanel.SetActive(true);
			break;
			default: break;
		}
	}
}
