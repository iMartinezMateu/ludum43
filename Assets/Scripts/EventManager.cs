using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour {
	[SerializeField]
	private HUDManager hudManager;

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

		hudManager.ShowEvent (curGoodEvent.text, options);

		Invoke ("InvokePositiveEvent", Random.Range (1, 10) * curGoodEvent.appearanceProbability);
	}

	void InvokeNegativeEvent () {
		List<string> options = new List<string> ();
		foreach (EventAnswer answer in curBadEvent.answers) {
			options.Add (answer.text);
		}

		hudManager.ShowEvent (curBadEvent.text, options);

		Invoke ("InvokeNegativeEvent", Random.Range (1, 10) * curBadEvent.appearanceProbability);
	}

}