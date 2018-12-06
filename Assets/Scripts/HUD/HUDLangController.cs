using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class HUDLangController : MonoBehaviour {

	public TextMeshProUGUI[] tooltipTexts;
	public TextMeshProUGUI[] losePanel;

	// Use this for initialization
	void Start () {
		GameLangManager l = GameLangManager.instance;

		tooltipTexts[0].text = l.GetTextByCode("GOLD");
		tooltipTexts[1].text = l.GetTextByCode("FOOD");
		tooltipTexts[2].text = l.GetTextByCode("RUM");
		tooltipTexts[3].text = l.GetTextByCode("WOOD");
		tooltipTexts[4].text = l.GetTextByCode("CANNON");
		tooltipTexts[5].text = l.GetTextByCode("CREW");
		
		losePanel[0].text = l.GetTextByCode("YOU_LOSE");
		losePanel[1].text = l.GetTextByCode("ENTER_NAME");
		losePanel[2].text = l.GetTextByCode("RESTART");
		losePanel[3].text = l.GetTextByCode("LOSE_MESSAGE");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
