using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopPanelController : MonoBehaviour {

	[SerializeField]
	private TextMeshProUGUI goldText;
	[SerializeField]
	private TextMeshProUGUI foodText;
	[SerializeField]
	private TextMeshProUGUI rumText;
	[SerializeField]
	private TextMeshProUGUI woodText;
	[SerializeField]
	private TextMeshProUGUI cannonText;
	[SerializeField]
	private TextMeshProUGUI peopleText;
	
	#region Unity Methods

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#endregion

	#region Public Methods

	public void SetGoldValue(int v){
		goldText.text = v.ToString();
	}

	public void SetFoodValue(int v){
		foodText.text = v.ToString();
	}

	public void SetWoodValue(int v){
		rumText.text = v.ToString();
	}

	public void SetRumValue(int v){
		woodText.text = v.ToString();
	}

	public void SetCannonValue(int v){
		cannonText.text = v.ToString();
	}

	public void SetPeopleValue(int v){
		peopleText.text = v.ToString();
	}

	#endregion
	
}
