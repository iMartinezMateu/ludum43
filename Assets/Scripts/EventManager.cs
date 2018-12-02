using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour {
	public HUDManager hudManager;
	public ResourceManager resourceManager;

	private Event currentEvent;

	private EventLists events;

	[SerializeField]
	private int secondsBetweenEvents;
	[SerializeField]
	private int badPercentage;

	void Start () {
		events = JsonMapper.ToObject<EventLists> (Resources.Load<TextAsset> ("EventsData").text);

		hudManager.AddClickEventOption (OnTriggerActionButton);

		StartCoroutine (InvokeEvent ());
	}

	private IEnumerator InvokeEvent () {
		int type = Random.Range (0, 100);
		if (type < badPercentage) {
			int index = Random.Range (0, events.badEvents.Length);
			currentEvent = events.badEvents[index];
		} else {
			int index = Random.Range (0, events.goodEvents.Length);
			currentEvent = events.goodEvents[index];
		}

		yield return new WaitForSeconds (secondsBetweenEvents);

		ShowEvent (currentEvent);
	}

	private void OnTriggerActionButton (int n) {
		if (n != -1){
			ProcessResources (currentEvent.answers[n]);
		}
		StartCoroutine (InvokeEvent ());
	}

	private void ShowEvent (Event e) {
		List<string> options = new List<string> ();
		foreach (EventAnswer answer in e.answers) {
			options.Add (answer.text);
		}
		hudManager.ShowEvent (e.text, options);
	}

	private void ProcessResources (EventAnswer ea) {
		foreach (Balance balance in ea.balances) {
			switch (balance.type) {
				case ResourceType.RUM:
					resourceManager.Rum += balance.quantity;
					hudManager.SetValue (ResourceType.RUM, resourceManager.Rum);
					break;
				case ResourceType.CREW:
					resourceManager.Crew += balance.quantity;
					hudManager.SetValue (ResourceType.CREW, resourceManager.Crew);
					break;
				case ResourceType.FOOD:
					resourceManager.Food += balance.quantity;
					hudManager.SetValue (ResourceType.FOOD, resourceManager.Food);
					break;
				case ResourceType.GUNS:
					resourceManager.Guns += balance.quantity;
					hudManager.SetValue (ResourceType.GUNS, resourceManager.Guns);
					break;
				case ResourceType.BOOTY:
					resourceManager.Booty += balance.quantity;
					hudManager.SetValue (ResourceType.BOOTY, resourceManager.Booty);
					break;
				case ResourceType.PIECES:
					resourceManager.Pieces += balance.quantity;
					hudManager.SetValue (ResourceType.PIECES, resourceManager.Pieces);
					break;
				default:
					break;
			}
		}
	}

}