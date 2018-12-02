using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopPanelController : MonoBehaviour {

	[SerializeField]
	private TextMeshProUGUI goldText;
	[SerializeField]
	private Slider foodSlider;
	[SerializeField]
	private Slider rumSlider;
	[SerializeField]
	private Slider woodSlider;
	[SerializeField]
	private Slider cannonSlider;
	[SerializeField]
	private Slider peopleSlider;
	
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

	public void SetFoodValue(float v){
		foodSlider.value = v;
	}

	public void SetWoodValue(float v){
		woodSlider.value = v;
	}

	public void SetRumValue(float v){
		rumSlider.value = v;
	}

	public void SetCannonValue(float v){
		cannonSlider.value = v;
	}

	public void SetPeopleValue(float v){
		cannonSlider.value = v;
	}

	#endregion
	
}
