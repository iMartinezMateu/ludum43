using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MenuLangController : MonoBehaviour {

	public TextMeshProUGUI[] mainButtonTexts;
	public TextMeshProUGUI startHistoryText;
	public TextMeshProUGUI[] startInstructionTexts;
	public TextMeshProUGUI[] optionSlidersTexts;

	/////EN/////
	private string[] mainButtonTexts_EN = {
		"Start", 
		"Options", 
		"Credits", 
		"Change language"
	};
	private string startHistoryText_EN = @"Welcome pirate, you're about to embark on the biggest story you've ever had.
You come from a long line of famous pirates and you should sound your name in the 7 seas.
The task of a good captain is not only: drink a lot of rum, shout to the sea and shoot your cannons to seagulls. 
You must control the happiness of your crew, equip your boat with the best guns, equip it with the toughest wood you can see, fill your reserves of the most luxurious food you have and keep the rum under lock and key.

The pirate community trusts you. This is your moment of glory and do not forget that an ARR.
It can sarrrrve your life.

Signed: King of the pirates.";
	private string[] startInstructionTexts_EN = {
		"How to play", 
		"Tap or click one option when the events spawn.", 
		"Your goal is to get the biggest treasure you can before you run out of resources.", 
		"Your crew needs food and rum or they will riot against you.", 
		"Be careful, if you run out of any resource... bad things can happen to you.",
		"Sometimes you have to fight another crews, you will need some cannons.",
		"Arrrr answers give you extra gold but also takes your most valued resources.",
		"Start"
	};
	private string[] optionSlidersTexts_EN = {
		"Music Volume", 
		"Effects Volume"
	};
	
	/////ES/////
	private string[] mainButtonTexts_ES = {
		"Iniciar", 
		"Opciones", 
		"Creditos", 
		"Cambiar idioma"
	};
	private string startHistoryText_ES = @"Bienvenido pirata, estás a punto de embarcarte en la mayor historia que nunca has tenido.
Provienes de una larga estirpe de famosos piratas y debes hacer sonar tu nombre en los 7 mares. 
La tarea de un buen capitán no es solo: beber mucho ron, gritar a la mar y disparar tus cañones a gaviotas. 
Debes controlar la felicidad de tu tripulación, equipar tu barco con los mejores cañones, dotarlo de la madera más resistente que veas, llenar tus reservas de la comida más lujosa que tengas y guardar el ron bajo llave.

La comunidad de piratas confía en ti. 
Este es tu momento de gloria y no olvides que un ARRRR puede salvarrrrte la vida.

Firmado: Rey de los piratas.";
	private string[] startInstructionTexts_ES = {
		"Como jugar", 
		"Toca o haz click en una opcion cuando el evento aparezca.", 
		"Tu mision es obtener el mayor tesoro posible antes de quedarte sin recursos.", 
		"Tu tripulacion necesita comida y ron o se amotinaran.", 
		"Cuidado, si te quedas sin algun recurso... te pueden pasar cosas horribles.",
		"A veces tendras que luchar contra otras tripulaciones, necesitaras cañones.",
		"Las respuetas Arrrr dan oro extra pero perderas parte de tus recusos escasos.",
		"Comenzar"
	};	
	private string[] optionSlidersTexts_ES = {
		"Volumen de la musica", 
		"Volumen de los efectos"
	};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RefreshMenuLang(){
		string l = GameManager.instance.currentLang;
		if (l == "en"){
			for (int i = 0; i < mainButtonTexts.Length; i++){
				mainButtonTexts[i].text = mainButtonTexts_EN[i];
			}
			for (int i = 0; i < startInstructionTexts.Length; i++){
				startInstructionTexts[i].text = startInstructionTexts_EN[i];
			}
			for (int i = 0; i < optionSlidersTexts.Length; i++){
				optionSlidersTexts[i].text = optionSlidersTexts_EN[i];
			}
			startHistoryText.text = startHistoryText_EN;
		} else if (l == "es"){
			for (int i = 0; i < mainButtonTexts.Length; i++){
				mainButtonTexts[i].text = mainButtonTexts_ES[i];
			}
			for (int i = 0; i < startInstructionTexts.Length; i++){
				startInstructionTexts[i].text = startInstructionTexts_ES[i];
			}
			for (int i = 0; i < optionSlidersTexts.Length; i++){
				optionSlidersTexts[i].text = optionSlidersTexts_ES[i];
			}
			startHistoryText.text = startHistoryText_ES;
		}
	}
}
