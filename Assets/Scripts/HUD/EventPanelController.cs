using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventPanelController : MonoBehaviour {

	[SerializeField]
	private Animator eventAnimator;
	[SerializeField]
	private TextMeshProUGUI eventText;
	[SerializeField]
	private Animator[] signAnimators;
	[SerializeField]
	private TextMeshProUGUI[] signTexts;

	public delegate void ClickEventOption(int o);
	public event ClickEventOption OnClickEventOption = delegate { };

	#region Unity Methods

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#endregion

	#region Public Methods

	public void ShowEventWithoutOptions(string text, int time){
		eventText.text = text;
		eventAnimator.SetBool("ShowWithoutEvents", true);
		StartCoroutine(HideEventWithoutOptions(time));
	}

	IEnumerator HideEventWithoutOptions(int time){
		yield return new WaitForSeconds(time);
		eventAnimator.SetBool("ShowWithoutEvents", false);
		OnClickEventOption(-1);
	}

	public void ShowEventWithOptions(string text, List<string> options){
		eventText.text = text;
		eventAnimator.SetBool("ShowWithEvents", true);
		for (int i = 0; i < options.Count; i++){
			signTexts[i].text = options[i];
			signAnimators[i].SetBool("Show", true);
		}
	}

	public void HideEventWithOptions(){
		eventAnimator.SetBool("ShowWithEvents", false);
		for (int i = 0; i < signAnimators.Length; i++) {
			signAnimators[i].SetBool("Show", false);
		}
	}

	public void HUDClickEventOption(int o){
		HideEventWithOptions();
		OnClickEventOption(o);
	}

	#endregion
}
