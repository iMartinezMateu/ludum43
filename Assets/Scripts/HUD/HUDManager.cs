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
		//eventPanelController.ShowEventWithoutOptions("Event without options", eventTextTimeOnScreen);

		List<string> options = new List<string>();
		options.Add("Una");
		options.Add("Dos");
		options.Add("Tres");
		eventPanelController.ShowEventWithOptions("Event with options", options);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#endregion

	#region Public Methods



	#endregion

}
