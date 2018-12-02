using System;
using LitJson;
using UnityEngine;

public class EventLoader : MonoBehaviour {

	public EventLists events;

	void Start(){
		var jsonString = Resources.Load<TextAsset>("test");

		events = JsonMapper.ToObject<EventLists>(jsonString.text);

		Debug.Log(events.goodEvents[0].answers[0].balances[0].quantity);
	}
}
