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
	public GameLangManager gameLangManager;

	private Event currentEvent;
	private EventLists events;

	[NonSerialized]
	public int eventCounter;
	[NonSerialized]
	public int fatalEventCounter;
	[NonSerialized]
	public int arrrrCounter;

	private int currentEventArrrrIndex = 0;
	private int betweenFatalEventsCounter = -1;

	[SerializeField]
	private int secondsBetweenEvents;
	[SerializeField]
	private int badEventsProbability;
    [SerializeField]
    private int battleEventsProbability;
    [SerializeField]
	private int normalEventsBetweenFatalEvents;
	[SerializeField]
	private int foodLostInEveryEvent;
	[SerializeField]
	private int happinessThreshold;
	[SerializeField]
	private int buoyancyThreshold;
	[SerializeField]
	private int foodThreshold;
	[SerializeField]
	private int fatalEventsToLose;

	void Start () {
		events = JsonMapper.ToObject<EventLists> (Resources.Load<TextAsset> ("EventsData_"+GameManager.instance.currentLang).text);

		hudManager.AddClickEventOption (OnTriggerActionButton);

		StartCoroutine (InvokeEvent ());
	}

	private IEnumerator InvokeEvent () {
		if (resourceManager.GetHappinessValue() < happinessThreshold && betweenFatalEventsCounter == -1){
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWHAPPINESS];
			fatalEventCounter++;
            Log.instance.ShowMessage(gameLangManager.GetTextByCode("CREW_NOW_HAPPY") + "\n" + fatalEventCounter + gameLangManager.GetTextByCode("RAGE_POINTS") );
			betweenFatalEventsCounter++;
		} else if (resourceManager.GetBuoyancyValue() < buoyancyThreshold && betweenFatalEventsCounter == -1) {
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWBUOYANCY];
			fatalEventCounter++;
            Log.instance.ShowMessage(gameLangManager.GetTextByCode("SHIP_DAMAGED") + "\n" + fatalEventCounter + gameLangManager.GetTextByCode("RAGE_POINTS"));
            betweenFatalEventsCounter++;
		} else if (resourceManager.Food < foodThreshold && betweenFatalEventsCounter == -1){
			currentEvent = events.conditionalEvents[(int)ConditionalEvents.LOWFOOD];
            Log.instance.ShowMessage(gameLangManager.GetTextByCode("NO_FOOD") + "\n" + fatalEventCounter + gameLangManager.GetTextByCode("RAGE_POINTS"));
            fatalEventCounter++;
			betweenFatalEventsCounter++;
		} else {
			int type = Random.Range (0, 100);
			if (type < badEventsProbability) {
				int index = Random.Range (0, events.badEvents.Length);
				currentEvent = events.badEvents[index];
			} else if (type > badEventsProbability+battleEventsProbability) {
				int index = Random.Range (0, events.goodEvents.Length);
				currentEvent = events.goodEvents[index];
			}
            else
            {
                currentEvent = GameObject.FindObjectOfType<Battle>().Fight();

            }
			if (betweenFatalEventsCounter > -1) {
				betweenFatalEventsCounter++;
				if (betweenFatalEventsCounter == normalEventsBetweenFatalEvents){
					betweenFatalEventsCounter = -1;
				}
			}
		}

		if (fatalEventCounter >= fatalEventsToLose){
            GameObject.FindObjectOfType<HUDManager>().ShowDead();
            
		} else {
			yield return new WaitForSeconds (secondsBetweenEvents);

			int negativeCount = 0;
			List<string> options = new List<string> ();
			foreach (EventAnswer answer in currentEvent.answers) {
				string answerText = answer.text;
				if (checkNegativeBalances(answer)) {
					answerText += "[disabled]";
					negativeCount++;
				}
				options.Add (answerText);
			}

			if (options.Count == negativeCount){
				GameObject.FindObjectOfType<HUDManager>().ShowDead();
			}

			if (options.Count > 1){
				int arrrrAnswer = findArrrrAnswer();
				currentEventArrrrIndex = arrrrAnswer;
				options[arrrrAnswer] += "[arrrr]";
			}

			hudManager.ShowEvent (currentEvent.text, options);

			eventCounter++;
		}
	}

	private void OnTriggerActionButton (int n) {
		AudioManager.instance.PlayAnswer1();
		ProcessResources (currentEvent.answers[n]);
		if (n == currentEventArrrrIndex) {
			arrrrCounter++;
		}
		StartCoroutine (InvokeEvent ());
	}

	private bool checkNegativeBalances(EventAnswer a) {
		foreach (Balance b in a.balances) {
			if (resourceManager.GetResource(b.type) + b.quantity < 0){
				return true;
			}
		}
		return false;
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
		//Food lost in Every Event
		resourceManager.Food -= foodLostInEveryEvent;
		hudManager.SetValue (ResourceType.FOOD, resourceManager.Food);
		//More
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