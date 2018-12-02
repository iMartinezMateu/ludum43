using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

	[SerializeField]
	private TopPanelController topPanelController;
	[SerializeField]
	private EventPanelController eventPanelController;

	[SerializeField]
	private int eventTextTimeOnScreen; 

	#region Unity Methods

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#endregion

	#region Public Methods

	public void SetValue(ResourceType type, int value){
		switch(type){
			case ResourceType.BOOTY:
				topPanelController.SetGoldValue(value);
			break;
			case ResourceType.CREW:
				topPanelController.SetPeopleValue(value);
			break;
			case ResourceType.FOOD:
				topPanelController.SetFoodValue(value);
			break;
			case ResourceType.GUNS:
				topPanelController.SetCannonValue(value);
			break;
			case ResourceType.PIECES:
				topPanelController.SetWoodValue(value);
			break;
			case ResourceType.RUM:
				topPanelController.SetRumValue(value);
			break;
			default: break;
		}
	}

	public void ShowEvent(string text, List<string> options){
		if (options.Count > 0){
			eventPanelController.ShowEventWithOptions(text, options);
		} else {
			eventPanelController.ShowEventWithoutOptions(text, eventTextTimeOnScreen);
		}
	}

	#endregion

}
