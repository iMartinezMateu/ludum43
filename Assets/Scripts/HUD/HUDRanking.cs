using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDRanking : MonoBehaviour {

    public EventManager myEventManager;
    public ResourceManager myResourceManager;
    private Animator rankingAnimator;
    public TextMeshProUGUI infoRankingText;
    public TMP_InputField playerName;
    private int gloryPoints; 

	// Use this for initialization
	void Start ()
    {
        rankingAnimator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseOrOpen()
    {
        rankingAnimator.SetBool("IsOpen", !rankingAnimator.GetBool("IsOpen"));
        CalculeGloryPoints();
        SetText();
    }

    private void CalculeGloryPoints()
    {
        float foodFactor = myResourceManager.Food *1.2f;
        float ronFactor = myResourceManager.Rum * 1.5f;
        float tripulationFactor = myResourceManager.Crew * 1.5f;
        float woodFactor = myResourceManager.Pieces * 2f;
        float shipPowerFactor= myResourceManager.GetResource(ResourceType.POWER) * 1.2f;
        float goldFactor = myResourceManager.Booty;
        float arrrrPoints = myEventManager.arrrrCounter *3;
        gloryPoints = (int)(foodFactor + ronFactor + tripulationFactor + woodFactor + shipPowerFactor + goldFactor + arrrrPoints);

    }

    private void SetText()
    {
        infoRankingText.text = playerName.text + ":  "+"x "+myEventManager.arrrrCounter +" Arr = " + gloryPoints + " Glory Points";
    }
}
