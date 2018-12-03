using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleManager : MonoBehaviour {

    public GameObject[] transformObjects;
    public UIParticleSystem[] myParticleSystem;
	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    ///<summary>
    ///position = position transform object to place particle.
    ///0 = Treasure, 1 = food, 2 = ron,3 = wood, 4 = cannons, 5 = Crew
    ///p_yDirection: 1 up, -1 down.
    ///</summary>
    public void PlayParticle(int p_position, int p_yDirection)
    {
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;
        if (p_yDirection == -1)
        {
            // Populate the color keys at the relative time 0 and 1 (0 and 100%)
            colorKey = new GradientColorKey[1];
            colorKey[0].color = Color.red;
            colorKey[0].time = 0.0f;

            // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
            alphaKey = new GradientAlphaKey[1];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;


            myParticleSystem[p_position].Gravity = -2;
            myParticleSystem[p_position].ColorOverLifetime.SetKeys(colorKey,alphaKey);
        }
        else
        {
            // Populate the color keys at the relative time 0 and 1 (0 and 100%)
            colorKey = new GradientColorKey[1];
            colorKey[0].color = Color.green;
            colorKey[0].time = 0.0f;

            // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
            alphaKey = new GradientAlphaKey[1];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;

            myParticleSystem[p_position].Gravity = 2;
            myParticleSystem[p_position].ColorOverLifetime.SetKeys(colorKey, alphaKey);
        }
        myParticleSystem[p_position].EmissionDirection.y = p_yDirection;
        myParticleSystem[p_position].Play();
    }
}
