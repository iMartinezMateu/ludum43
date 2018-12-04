using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems; //required for Event data


public class TopPanelController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler {

	[SerializeField]
	private GameObject goldImage;
	[SerializeField]
	private GameObject foodImage;
	[SerializeField]
	private GameObject rumImage;
	[SerializeField]
	private GameObject woodImage;
	[SerializeField]
	private GameObject cannonImage;
	[SerializeField]
	private GameObject crewImage;
	
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
	
	GameObject currentHover;

	
	#region Unity Methods

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/* if (currentHover != null)
		{
			goldImage.SetActive(true);
			foodImage.SetActive(true);
			rumImage.SetActive(true);
			woodImage.SetActive(true);
			cannonImage.SetActive(true);
			crewImage.SetActive(true);
		}
		else
		{
			goldImage.SetActive(false);
			foodImage.SetActive(false);
			rumImage.SetActive(false);
			woodImage.SetActive(false);
			cannonImage.SetActive(false);
			crewImage.SetActive(false);
		}*/
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
			Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
			currentHover = eventData.pointerCurrentRaycast.gameObject;
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		currentHover = null;
	}

	#endregion
	
}
