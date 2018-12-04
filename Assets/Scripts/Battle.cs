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

    public Event Fight()
    {

        int enemyPower = Random.Range(100, 200);
        string winText = "";
        Balance[] balances = new Balance[0];
        
        if (resources.GetPowerValue() > enemyPower)
        {
            winText = "You Won!";
            balances = new Balance[]
            {
                new Balance()
                {
                    type=ResourceType.BOOTY,
                    quantity = bootyWon
                }
            };
        }

        else
        {
            winText = "You lose the battle";
            balances = new Balance[]
            {
                new Balance()
                {
                    type = ResourceType.PIECES,
                    quantity = -piecesLost
                },
                new Balance()
                {
                    type = ResourceType.CREW,
                    quantity = -crewLost
                },
                new Balance()
                {
                    type = ResourceType.BOOTY,
                    quantity = -bootyLost
                }
            };
        }



        return new Event()
        {
            text = "Pirate Battle!! \n Your power: " + resources.GetPowerValue() + "\n Enemy power: " + enemyPower + "\n" + winText,
            answers = new EventAnswer[1]
            {
                new EventAnswer()
                {
                    text="OK",
                    balances = balances
                }
            }
        };


    }

    void Win()
    {
        resources.Booty += bootyWon;
    }

    void Lose()
    {
        resources.Pieces -= piecesLost;
        resources.Crew -= crewLost;
        resources.Booty -= bootyLost;
    }
}
