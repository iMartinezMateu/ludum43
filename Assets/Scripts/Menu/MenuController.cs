using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	[SerializeField]
	private GameObject mainPanel;
	[SerializeField]
	private GameObject startPanel;
	[SerializeField]
	private GameObject optionsPanel;
	[SerializeField]
	private GameObject creditsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeMusicVolume(float n){
		GameManager.instance.musicVolume = n;
	}

	public void ChangeEffectsVolume(float n){
		GameManager.instance.effectVolume = n;
	}

	public void ChangePanel(string scene){
		switch(scene) {
			case "main":
				mainPanel.SetActive(true);
				startPanel.SetActive(false);
				optionsPanel.SetActive(false);
				creditsPanel.SetActive(false);

				GameManager.instance.ChangeScene(1);
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
