using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {
	public GameLangManager gameLangManager;
    static ResourceManager resources;

    public int piecesLost, crewLost, bootyLost;
    public int bootyWon;

    private void Start()
    {
        gameLangManager = GameObject.FindObjectOfType<GameLangManager>();
        resources = GameObject.FindObjectOfType<ResourceManager>();
    }

    public Event Fight()
    {

        int enemyPower = Random.Range(100, 200);
        string winText = "";
        Balance[] balances = new Balance[0];
        
        if (resources.GetPowerValue() > enemyPower)
        {
            winText = gameLangManager.GetTextByCode("YOU_WON");
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
            winText = gameLangManager.GetTextByCode("YOU_LOSE");
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
            text = gameLangManager.GetTextByCode("PIRATE_BATTLE")+"\n"+gameLangManager.GetTextByCode("YOUR_POWER") + resources.GetPowerValue() + "\n" + gameLangManager.GetTextByCode("ENEMY_POWER") + enemyPower + "\n" + winText,
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
