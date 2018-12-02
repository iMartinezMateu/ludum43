using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {
	BOOTY = 0,
	PIECES,
	CREW,
	RUM,
	FOOD,
	GUNS
}

public class ResourceManager : MonoBehaviour {
	
	private int booty = 0;
	private int pieces = 0;
	private int crew = 0;
	private int rum = 0;
	private int food = 0;
	private int guns = 0;

	private int happiness = 0;
	private int buoyancy = 0;
	private int power = 0;

	#region Unity methods

	// Use this for initialization
	void Start () {

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
		}
	}

	public int Pieces {
		get {
			return pieces;
		}
		set {
			pieces = value;
			UpdateBuoyancy ();
		}
	}

	public int Crew {
		get {
			return crew;
		}
		set {
			crew = value;
			UpdateHappiness ();
			UpdateBuoyancy ();
		}
	}

	public int Rum {
		get {
			return rum;
		}
		set {
			rum = value;
			UpdateHappiness ();
		}
	}

	public int Food {
		get {
			return food;
		}
		set {
			food = value;
			UpdateHappiness ();
		}
	}

	public int Guns {
		get {
			return guns;
		}
		set {
			guns = value;
			UpdateBuoyancy ();
		}
	}

	void UpdateHappiness () {
		int crewMultiplier = 1;
		int foodMultiplier = 3;
		int rumMultiplier = 5;
		happiness = (food * foodMultiplier + rum * rumMultiplier) / (crew * crewMultiplier + food * foodMultiplier + rum * rumMultiplier);
	}

	void UpdateBuoyancy () {
		int piecesMultiplier = 10;
		int crewMultiplier = 2;
		int gunMultiplier = 1;
		buoyancy = (pieces * piecesMultiplier) / (pieces * piecesMultiplier + crew * crewMultiplier + guns * gunMultiplier);
	}

	void UpdatePower () {
		int crewMultiplier = 1;
		int gunMultiplier = 3;
		power = crew * crewMultiplier + guns * gunMultiplier;
	}

	int GetHappinessValue () {
		return happiness;
	}

	int GetBuoyancyValue () {
		return buoyancy;
	}

	int GetPowerValue () {
		return power;
	}
	
	#endregion

}
