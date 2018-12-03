using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

enum ConditionalEvents {
	LOWHAPPINESS = 0,
	LOWBUOYANCY = 1,
	LOWFOOD = 2
}

public class EventManager : MonoBehaviour {
	public HUDManager hudManager;
	public ResourceManager resourceManager;

	private Event currentEvent;
	private EventLists events;

	[NonSerialized]
	public int eventCounter;
	[NonSerialized]
	public int fatalEventCounter;
	[NonSerialized]
	public int arrrrCounter;

	private int betweenFatalEventsCounter = -1;

	[SerializeField]
	private int secondsBetweenEvents;
	[SerializeField]
	private int badEventsProbability;
	[SerializeField]
	private int normalEventsBetweenFatalEvents;
	[SerializeField]
	private int happinessThreshold;
	[SerializeField]
	private int buoyancyThreshold;
	[SerializeField]
	private int foodThreshold;
	[SerializeField]
	private int fatalEventsToLose;

	void Start () {
		events = JsonMapper.ToObject<EventLists> (Resources.Load<TextAsset> ("EventsData").text);

		hudManager.AddClickEventOption (OnTriggerActionButton);

		StartCoroutine (InvokeEvent ());
	}

	private IEnumerator InvokeEvent () {
		if (resourceManager.GetHappinessValue() < happinessThreshold && betweenFatalEventsCounter == -1){
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWHAPPINESS];
			fatalEventCounter++;
			betweenFatalEventsCounter++;
		} else if (resourceManager.GetBuoyancyValue() < buoyancyThreshold && betweenFatalEventsCounter == -1) {
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWBUOYANCY];
			fatalEventCounter++;
			betweenFatalEventsCounter++;
		} else if (resourceManager.Food < foodThreshold && betweenFatalEventsCounter == -1){
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWFOOD];
			fatalEventCounter++;
			betweenFatalEventsCounter++;
		} else {
			int type = Random.Range (0, 100);
			if (type < badEventsProbability) {
				int index = Random.Range (0, events.badEvents.Length);
				currentEvent = events.badEvents[index];
			} else {
				int index = Random.Range (0, events.goodEvents.Length);
				currentEvent = events.goodEvents[index];
			}
			if (betweenFatalEventsCounter > -1) {
				betweenFatalEventsCounter++;
				if (betweenFatalEventsCounter == normalEventsBetweenFatalEvents){
					betweenFatalEventsCounter = -1;
				}
			}
		}

		if (fatalEventCounter >= fatalEventsToLose){
			//Lose Panel
		} else {
			yield return new WaitForSeconds (secondsBetweenEvents);

			List<string> options = new List<string> ();
			foreach (EventAnswer answer in currentEvent.answers) {
				options.Add (answer.text);
			}

			if (options.Count > 1){
				int arrrrAnswer = findArrrrAnswer();

				options[arrrrAnswer] += "[arrrr]";
			}

			hudManager.ShowEvent (currentEvent.text, options);

			eventCounter++;
		}
	}

	private void OnTriggerActionButton (int n) {
		ProcessResources (currentEvent.answers[n]);
		StartCoroutine (InvokeEvent ());
	}

	//Obtener la respuesta que mas joda al jugador
	private int findArrrrAnswer() {
		int currentAnswerIndex = 0;
		int newQuantity = int.MaxValue;

		for (int i = 0; i < currentEvent.answers.Length; i++) {
			for (int j = 0; j < currentEvent.answers[i].balances.Length; j++){
				Balance b = currentEvent.answers[i].balances[j];
				if (b.type != ResourceType.BOOTY && resourceManager.GetResource(b.type) + b.quantity < newQuantity){
					currentAnswerIndex = i;
					newQuantity = resourceManager.GetResource(b.type) + b.quantity;
				}
			}
		}

		return currentAnswerIndex;
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