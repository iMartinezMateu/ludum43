using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {
	BOOTY = 0,
	PIECES = 1,
	CREW = 2,
	RUM = 3,
	FOOD = 4,
	GUNS = 5,
	HAPPINESS = 6,
	BUOYANCY = 7,
	POWER = 8
}

public class ResourceManager : MonoBehaviour {
	public HUDManager hudManager;
	public EventManager eventManager;

	[SerializeField]
	private int booty = 0;
	[SerializeField]
	private int pieces = 0;
	[SerializeField]
	private int crew = 0;
	[SerializeField]
	private int rum = 0;
	[SerializeField]
	private int food = 0;
	[SerializeField]
	private int guns = 0;

	private int happiness = 0;
	private int buoyancy = 0;
	private int power = 0;

	#region Unity methods

	void Awake()
	{
		UpdateHappiness ();
		UpdateBuoyancy ();
		UpdatePower ();
	}

	// Use this for initialization
	void Start () {
		hudManager.SetValue (ResourceType.BOOTY, booty);
		hudManager.SetValue (ResourceType.PIECES, pieces);
		hudManager.SetValue (ResourceType.CREW, crew);
		hudManager.SetValue (ResourceType.RUM, rum);
		hudManager.SetValue (ResourceType.FOOD, food);
		hudManager.SetValue (ResourceType.GUNS, guns);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region public methods

	public int Booty {
		get {
			return booty;
		}
		set {
            booty = value;
            
            if (booty < 0) booty = 0;
                else if (booty > 999) booty = 999;
		}
	}

	public int Pieces {
		get {
			return pieces;
		}
		set {
            pieces = value;

            if (pieces < 0) pieces = 0;
			else if (pieces > 999) pieces = 999;

			UpdateBuoyancy ();
		}
	}

	public int Crew {
		get {
			return crew;
		}
		set {
            crew = value;

            if (crew < 0) crew = 0;
			else if (crew > 999) crew = 999;

			UpdateHappiness ();
			UpdateBuoyancy ();
			UpdatePower ();
		}
	}

	public int Rum {
		get {
			return rum;
		}
		set {
            rum = value;

            if (rum < 0) rum = 0;
			else if (rum > 999) rum = 999;

			UpdateHappiness ();
		}
	}

	public int Food {
		get {
			return food;
		}
		set {
            food = value;

			if (food < eventManager.warningEventsThresholds[(int)ResourceType.FOOD]){
				Log.instance.ShowMessage(GameLangManager.instance.GetTextByCode("NO_FOOD"));
			}

            if (food < 0) food = 0;
			else if (food > 999) food = 999;
			UpdateHappiness ();
		}
	}

	public int Guns {
		get {
			return guns;
		}
		set {
            guns = value;

            if (guns < 0) guns = 0;
			else if (guns > 999) guns = 999;
			UpdateBuoyancy ();
			UpdatePower ();
		}
	}

	public int GetResource (ResourceType r) {
		int ret = 0;
		switch(r){
			case ResourceType.BOOTY:
				ret = booty;
			break;
			case ResourceType.CREW:
				ret = crew;
			break;
			case ResourceType.FOOD:
				ret = food;
			break;
			case ResourceType.GUNS:
				ret = guns;
			break;
			case ResourceType.PIECES:
				ret = pieces;
			break;
			case ResourceType.RUM:
				ret = rum;
			break;
			case ResourceType.HAPPINESS:
				ret = happiness;
			break;
			case ResourceType.BUOYANCY:
				ret = buoyancy;
			break;
			case ResourceType.POWER:
				ret = power;
			break;
			default: break;
		}
		return ret;
	}

	#endregion

	#region private methods

	private void UpdateHappiness () {
		int crewMultiplier = 1;
		int foodMultiplier = 2;
		int rumMultiplier = 4;
		happiness = (int)((float)((float)(food * foodMultiplier + rum * rumMultiplier) / (float)(crew * crewMultiplier + food * foodMultiplier + rum * rumMultiplier))*100);
		
		if (happiness < eventManager.warningEventsThresholds[(int)ResourceType.HAPPINESS]){
			Log.instance.ShowMessage(GameLangManager.instance.GetTextByCode("CREW_NOT_HAPPY"));
		}

		GameObject.FindObjectOfType<HUDManager>().SetHappinessValue(happiness);
	}

	private void UpdateBuoyancy () {
		int piecesMultiplier = 8;
		int crewMultiplier = 2;
		int gunMultiplier = 1;
		buoyancy = (int)((float)((float)(pieces * piecesMultiplier) / (float)(pieces * piecesMultiplier + crew * crewMultiplier + guns * gunMultiplier))*100);
		
		if (buoyancy < eventManager.warningEventsThresholds[(int)ResourceType.BUOYANCY]){
			Log.instance.ShowMessage(GameLangManager.instance.GetTextByCode("SHIP_DAMAGED"));
		}
		
		GameObject.FindObjectOfType<Ship>().RefreshStat((float)buoyancy/100);
	}

	private void UpdatePower () {
		int crewMultiplier = 1;
		int gunMultiplier = 3;
		power = crew * crewMultiplier + guns * gunMultiplier;
	}

	#endregion

}