using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDRanking : MonoBehaviour {

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
        float foodFactor = 1f *1.2f;
        float ronFactor = 1f *1.5f;
        float tripulationFactor = 1f * 1.5f;
        float woodFactor = 1f * 2f;
        float shipPowerFactor= 1f * 1.2f;
        float goldFactor = 1;

        gloryPoints = (int)(foodFactor + ronFactor + tripulationFactor + woodFactor + shipPowerFactor + goldFactor);

    }
    private void SetText()
    {
        infoRankingText.text = playerName.text + ":  " + gloryPoints +" Glory Points";
    }
}
