﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventPanelController : MonoBehaviour {

	[NonSerialized]
	public int eventTextTimeOnScreen = 0; 
	private float timer;

	[SerializeField]
	private Animator eventAnimator;
	[SerializeField]
	private TextMeshProUGUI eventText;
	[SerializeField]
	private Slider eventTimerSlider;
	[SerializeField]
	private Animator[] signAnimators;
	[SerializeField]
	private Button[] signButtons;
	[SerializeField]
	private TextMeshProUGUI[] signTexts;
	[SerializeField]
	private GameObject[] arrrrTexts;

	public delegate void ClickEventOption(int o);
	public event ClickEventOption OnClickEventOption = delegate { };

	#region Unity Methods

	// Use this for initialization
	void Start () {
		eventTimerSlider.minValue = 0;
		eventTimerSlider.maxValue = eventTextTimeOnScreen;
	}
	
	// Update is called once per frame
	void Update () {
		if (eventTimerSlider.IsActive()){
			timer += Time.deltaTime;
			eventTimerSlider.value = timer;
		}
	}

	#endregion

	#region Public Methods

	public void ShowEventWithoutOptions(string text){
		AudioManager.instance.PlayEvent();
		timer = 0;
		eventText.text = text;
		StartCoroutine(EventWithoutOptionsAnimation());
	}

	IEnumerator EventWithoutOptionsAnimation(){
		AudioManager.instance.PlayEvent();
		eventTimerSlider.gameObject.SetActive(true);
		eventAnimator.SetBool("ShowWithoutEvents", true);

		yield return new WaitForSeconds(eventTextTimeOnScreen);

		eventAnimator.SetBool("ShowWithoutEvents", false);
		eventTimerSlider.gameObject.SetActive(false);

		OnClickEventOption(0);
	}

	public void ShowEventWithOptions(string text, List<string> options){
		AudioManager.instance.PlayEvent();
		eventText.text = text;
		eventAnimator.SetBool("ShowWithEvents", true);
		for (int i = 0; i < options.Count; i++){
			string optionText = options[i];

			if (optionText.IndexOf("[arrrr]") > -1) {
				optionText = optionText.Replace("[arrrr]", "");
				arrrrTexts[i].SetActive(true);
			}
			if (optionText.IndexOf("[disabled]") > -1) {
				optionText = optionText.Replace("[disabled]", "");
				signButtons[i].interactable = false;
			}

			signTexts[i].text = optionText;
			signAnimators[i].SetBool("Show", true);
		}
	}

	public void HideEventWithOptions(){
		eventAnimator.SetBool("ShowWithEvents", false);
		for (int i = 0; i < signAnimators.Length; i++) {
			signAnimators[i].SetBool("Show", false);
		}

		StartCoroutine(ResetOptions());
	}

	public IEnumerator ResetOptions(){
		yield return new WaitForSeconds(1);
		for (int i = 0; i < signAnimators.Length; i++) {
			signTexts[i].text = "";
			arrrrTexts[i].SetActive(false);
			signButtons[i].interactable = true;
		}
	}

	public void HUDClickEventOption(int o){
		HideEventWithOptions();
		OnClickEventOption(o);
	}

	#endregion
}
