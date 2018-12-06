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

public class LowResourceEvent : Event
{
	public ResourceType type;
}

public class Event 
{
	public String text;

	public EventAnswer[] answers;
	
	public int spawnCounter = 0;
}

public class EventLists  {
	public Event[] goodEvents;
	public Event[] badEvents;
	public LowResourceEvent[] conditionalEvents;
}
