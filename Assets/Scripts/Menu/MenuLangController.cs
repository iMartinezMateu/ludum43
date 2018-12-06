using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MenuLangController : MonoBehaviour {

	public TextMeshProUGUI[] mainMenuTexts;
	public TextMeshProUGUI[] startMenuTexts;
	public TextMeshProUGUI[] optionsMenuTexts;
	public TextMeshProUGUI[] creditsMenuTexts;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RefreshMenuLang(){
		GameLangManager l = GameLangManager.instance;

		mainMenuTexts[0].text = l.GetTextByCode("START");
		mainMenuTexts[1].text = l.GetTextByCode("OPTIONS");
		mainMenuTexts[2].text = l.GetTextByCode("CREDITS");
		mainMenuTexts[3].text = l.GetTextByCode("CHANGE_LANGUAGE");

		startMenuTexts[0].text = l.GetTextByCode("HOW_TO_PLAY");
		startMenuTexts[1].text = l.GetTextByCode("TAP_CLICK_INSTRUCTION");
		startMenuTexts[2].text = l.GetTextByCode("YOUR_GOAL_INSTRUCTION");
		startMenuTexts[3].text = l.GetTextByCode("CREW_NEEDS_INSTRUCTION");
		startMenuTexts[4].text = l.GetTextByCode("BE_CAREFUL_INSTRUCTION");
		startMenuTexts[5].text = l.GetTextByCode("CREW_BATTLES_INSTRUCTION");
		startMenuTexts[6].text = l.GetTextByCode("ARRR_ANSWERS_INSTRUCTION");
		startMenuTexts[7].text = l.GetTextByCode("HISTORY_TEXT");
		startMenuTexts[8].text = l.GetTextByCode("START");

		optionsMenuTexts[0].text = l.GetTextByCode("MUSIC_VOLUME");
		optionsMenuTexts[1].text = l.GetTextByCode("EFFECTS_VOLUME");

		creditsMenuTexts[0].text = l.GetTextByCode("CREDITS");
	}
}
