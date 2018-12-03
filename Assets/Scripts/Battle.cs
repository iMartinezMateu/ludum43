using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    public int piecesLost, crewLost, bootyLost;
    public int bootyWon;

    static ResourceManager resources;

    private void Start()
    {
        resources = GameObject.FindObjectOfType<ResourceManager>();
    }

    public void Fight(out int enemyPower, out bool win)
    {
        enemyPower = Random.Range(50, 150);

        if (resources.GetPowerValue() > enemyPower)
        {
            Win();
            win = true;
        }

        else
        {
            Lose();
            win = false;
        }
    }

    void Win()
    {
        resources.Booty += bootyWon;
        Log.instance.SendMessage("Yaaay! We won the battle!!");
    }

    void Lose()
    {
        resources.Pieces -= piecesLost;
        resources.Crew -= crewLost;
        resources.Booty -= bootyLost;
        Log.instance.SendMessage("Bastards! We lost the battle!");
    }
}
