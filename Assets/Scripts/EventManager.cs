using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
	public HUDManager hudManager;
	public ResourceManager resourceManager;

	private Event curGoodEvent;
	private Event curBadEvent;

	private EventLists events;

	void Start () {
		var jsonString = Resources.Load<TextAsset> ("test");
		events = JsonMapper.ToObject<EventLists> (jsonString.text);
		foreach (Event item in events.goodEvents) {
			curGoodEvent = item;
			Invoke ("InvokePositiveEvent", Random.Range (1, 10) * item.appearanceProbability);

		}
		foreach (Event item in events.badEvents) {
			curBadEvent = item;
			Invoke ("InvokeNegativeEvent", Random.Range (1, 10) * item.appearanceProbability);
		}

	}

	void InvokePositiveEvent () {
		List<string> options = new List<string> ();
		foreach (EventAnswer answer in curGoodEvent.answers) {
			options.Add (answer.text);
		}
		hudManager.AddClickEventOption(GetGoodDialogButton);
		hudManager.ShowEvent (curGoodEvent.text, options);

		Invoke ("InvokePositiveEvent", Random.Range (1, 10) * curGoodEvent.appearanceProbability);
	}

	void InvokeNegativeEvent () {
		List<string> options = new List<string> ();
		foreach (EventAnswer answer in curBadEvent.answers) {
			options.Add (answer.text);
		}
		hudManager.AddClickEventOption(GetBadDialogButton);
		hudManager.ShowEvent (curBadEvent.text, options);


		Invoke ("InvokeNegativeEvent", Random.Range (1, 10) * curBadEvent.appearanceProbability);
	}
	
	void GetGoodDialogButton(int n) {
		foreach (Balance balance in curGoodEvent.answers[n].balances)
		{
			switch (balance.type)
			{
				case ResourceType.RUM:
					resourceManager.rum +=balance.quantity;
					break;
				case ResourceType.CREW:
					resourceManager.crew += balance.quantity;
					break;
				case ResourceType.FOOD:
					resourceManager.food += balance.quantity;
					break;
				case ResourceType.GUNS:
					resourceManager.guns += balance.quantity;
					break;
				case ResourceType.BOOTY:
					resourceManager.booty += balance.quantity;
					break;
				case ResourceType.PIECES:
					resourceManager.pieces += balance.quantity;
					break;
			}
		}
	}
	
	void GetBadDialogButton(int n) {
		foreach (Balance balance in curBadEvent.answers[n].balances)
		{
			switch (balance.type)
			{
				case ResourceType.RUM:
					resourceManager.rum +=balance.quantity;
					break;
				case ResourceType.CREW:
					resourceManager.crew += balance.quantity;
					break;
				case ResourceType.FOOD:
					resourceManager.food += balance.quantity;
					break;
				case ResourceType.GUNS:
					resourceManager.guns += balance.quantity;
					break;
				case ResourceType.BOOTY:
					resourceManager.booty += balance.quantity;
					break;
				case ResourceType.PIECES:
					resourceManager.pieces += balance.quantity;
					break;
			}
		}
	}


}