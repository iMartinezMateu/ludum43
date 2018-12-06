using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems; //required for Event data


public class TopPanelController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler {
	
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

	[SerializeField]
	private Image crewHappinessImage;
	[SerializeField]
	private Sprite[] happinessStates;
	
	[SerializeField]
	private GameObject tooltipContainer;
	private GameObject currentHover;

	
	#region Unity Methods

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHover != null)
		{
			tooltipContainer.SetActive(true);
		}
		else
		{
			tooltipContainer.SetActive(false);
		}
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
		woodText.text = v.ToString();
	}

	public void SetRumValue(int v){
		rumText.text = v.ToString();
	}

	public void SetCannonValue(int v){
		cannonText.text = v.ToString();
	}

	public void SetPeopleValue(int v){
		peopleText.text = v.ToString();
	}

	public void SetHappinessFace(int h){
		if (h <= 33){
			crewHappinessImage.sprite = happinessStates[0];
		} else if (h > 33 && h <= 66){
			crewHappinessImage.sprite = happinessStates[1];
		} else if (h > 66) {
			crewHappinessImage.sprite = happinessStates[2];
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerCurrentRaycast.gameObject != null && !eventData.pointerCurrentRaycast.gameObject.name.Equals("TopPanel") ) {
			currentHover = eventData.pointerCurrentRaycast.gameObject;
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		currentHover = null;
	}

	#endregion
	
}
