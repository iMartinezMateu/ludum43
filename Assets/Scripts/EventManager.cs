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

	private EventLists events;
	private Event currentEvent;
	private int currentEventArrrrIndex;

	[NonSerialized]
	public int eventCounter;
	[NonSerialized]
	public int arrrrCounter;

	[Header("General event properties")]
	[SerializeField]
	private int secondsBetweenEvents;

	[Header("Food Properties")]
	[SerializeField]
	private int foodLostInEveryEvent;

	[Header("Event probabilities")]
	[SerializeField]
	private int badEventsProbability;
    [SerializeField]
    private int battleEventsProbability;

	[Header("WarningEvents")]
	[SerializeField]
	public int[] warningEventsThresholds;
	[NonSerialized]
	public bool[] warningEventsTriggered;

	void Start () {
		events = JsonMapper.ToObject<EventLists> (Resources.Load<TextAsset> ("EventsData_"+GameManager.instance.currentLang).text);

		warningEventsTriggered = new bool[warningEventsThresholds.Length];
		for (int i = 0; i < warningEventsTriggered.Length; i++){
			warningEventsTriggered[i] = false;
		}

		hudManager.AddClickEventOption (OnTriggerActionButton);

		StartCoroutine (InvokeEvent ());
	}

	private IEnumerator InvokeEvent () {
		Event nextEvent = SelectNextEvent();
		
		yield return new WaitForSeconds (secondsBetweenEvents);

		ProcessEvent(nextEvent);
	}

	private void OnTriggerActionButton (int n) {
		AudioManager.instance.PlayAnswer1();
		ProcessResources (n);
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

	private void ProcessEvent(Event ev){
		int negativeCount = 0;
		List<string> options = new List<string> ();
		foreach (EventAnswer answer in ev.answers) {
			string answerText = answer.text;
			if (checkNegativeBalances(answer)) {
				answerText += "[disabled]";
				negativeCount++;
			}
			options.Add (answerText);
		}

		if (options.Count == negativeCount){
			GameObject.FindObjectOfType<HUDManager>().ShowDead();
			return;
		}

		if (options.Count > 1){
			int arrrrAnswer = findArrrrAnswer(ev);
			currentEventArrrrIndex = arrrrAnswer;
			options[arrrrAnswer] += "[arrrr]";
		}

		hudManager.ShowEvent (ev.text, options);

		currentEvent = ev;
		eventCounter++;
	}
	
	private Event SelectNextEvent(){
		foreach (LowResourceEvent e in events.conditionalEvents){
			if (resourceManager.GetResource(e.type) < warningEventsThresholds[(int)e.type] && !warningEventsTriggered[(int)e.type]){
				warningEventsTriggered[(int)e.type] = true;
				return e;
			}
		}

		int type = Random.Range (0, 100);
		if (type < badEventsProbability) {
			int index = Random.Range (0, events.badEvents.Length);
			return events.badEvents[index];
		} else if (type > badEventsProbability+battleEventsProbability) {
			int index = Random.Range (0, events.goodEvents.Length);
			return events.goodEvents[index];
		} else {
			return GameObject.FindObjectOfType<Battle>().Fight();

		}
	}

	//Obtener la respuesta que mas joda al jugador
	private int findArrrrAnswer(Event ev) {
		int currentAnswerIndex = 0;
		int newQuantity = int.MaxValue;

		for (int i = 0; i < ev.answers.Length; i++) {
			for (int j = 0; j < ev.answers[i].balances.Length; j++){
				Balance b = ev.answers[i].balances[j];
				if (b.type != ResourceType.BOOTY && resourceManager.GetResource(b.type) + b.quantity < newQuantity){
					currentAnswerIndex = i;
					newQuantity = resourceManager.GetResource(b.type) + b.quantity;
				}
			}
		}

		return currentAnswerIndex;
	}

	//Procesar los recursos
	private void ProcessResources (int n) {
		//Process Arrrr
		if (n == currentEventArrrrIndex) arrrrCounter++;
		//Food lost in Every Event
		resourceManager.Food -= foodLostInEveryEvent;
		hudManager.SetValue (ResourceType.FOOD, resourceManager.Food);
		//More
		foreach (Balance balance in currentEvent.answers[n].balances) {
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