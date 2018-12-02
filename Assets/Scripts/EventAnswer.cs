using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public enum Type
{
    BOOTY,PIECES,CREW,RUM,FOOD,GUNS
}

public class EventAnswer : MonoBehaviour
{
    public String answer;
    public Type powerupType;
    public int powerupTypeQuantity;
    public Type decreaseType;
    public int decreaseTypeQuantity;
}
