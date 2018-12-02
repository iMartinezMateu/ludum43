using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    BOOTY = 0,
	PIECES,
	CREW,
	RUM,
	FOOD,
	GUNS
}

public class ResourceManager : MonoBehaviour
{
	public int booty = 0;
	public int pieces = 0;
	public int crew = 0;
	public int rum = 0;
	public int food = 0;
	public int guns = 0;

	public int happiness = 0;
	public int buoyancy = 0;
	public int power = 0;

	int GetBootyValue()
	{
		return booty;
	}

	int GetPiecesValue()
	{
		return pieces;
	}

	int GetCrewValue()
	{
		return crew;
	}

	int GetRumValue()
	{
		return rum;
	}

	int GetFoodValue()
	{
		return food;
	}

	int GetGunsValue()
	{
		return guns;
	}

	int GetHappinessValue()
	{
		return happiness;
	}

	int GetBuoyancyValue()
	{
		return buoyancy;
	}

	int GetPowerValue()
	{
		return power;
	}
	
	void UpdateBooty(int value)
	{
		booty = value;
	}

	void UpdatePieces(int value)
	{
		pieces = value;
	}

	void UpdateCrew(int value)
	{
		crew = value;
	}

	void UpdateRum(int value)
	{
		rum = value;
	}

	void UpdateFood(int value)
	{
		food = value;
	}

	void UpdateGuns(int value)
	{
		guns = value;
	}

	void UpdateHappiness(int value)
	{
		happiness = value;
	}

	void UpdateBuoyancy(int value)
	{
		buoyancy = value;
	}

	void UpdatePower(int value)
	{
		power = value;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
