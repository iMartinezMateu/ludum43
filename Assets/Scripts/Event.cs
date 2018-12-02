using System;

public class Balance 
{
	public ResourceType type;
	public int quantity;
}

public class EventAnswer
{
    public String text;

    public Balance[] balances;
}

public class Event 
{
	public String text;
	public float appearanceProbability;

	public EventAnswer[] answers;
}
