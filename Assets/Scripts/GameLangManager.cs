using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLangManager : MonoBehaviour {

	private Dictionary<string, string> dictionary_es;
	private Dictionary<string, string> dictionary_en;

	// Use this for initialization
	void Start () {
		dictionary_en = new Dictionary<string, string>();
		dictionary_es = new Dictionary<string, string>();

		dictionary_en.Add("CREW_NOT_HAPPY", "Your crew aren't happy captain!!");
		dictionary_en.Add("SHIP_DAMAGED", "Captain, your ship seems damaged, you are about to sink!!");
		dictionary_en.Add("NO_FOOD", "You can't subsist without food!!");
		dictionary_en.Add("RAGE_POINTS", "Rage points");
		dictionary_en.Add("NEED_MORE_WOOD", "We need more wood t' keep this afloat");
		dictionary_en.Add("YOU_WON", "You won!");
		dictionary_en.Add("YOU_LOSE", "You lose!");
		dictionary_en.Add("PIRATE_BATTLE", "Pirate Battle!!");
		dictionary_en.Add("YOUR_POWER", "Your power: ");
		dictionary_en.Add("ENEMY_POWER", "Enemy power: ");

		dictionary_es.Add("CREW_NOT_HAPPY", "Capitan, tu tripulacion no esta feliz!");
		dictionary_es.Add("SHIP_DAMAGED", "Capitan, tu barco esta dañado, estais apunto de naufragar!");
		dictionary_es.Add("NO_FOOD", "Capitan, no podeis vivir sin comida!");
		dictionary_es.Add("RAGE_POINTS", "Puntos de furia");
		dictionary_es.Add("NEED_MORE_WOOD", "Necesitamos mas madera para mantenernos a flote");
		dictionary_es.Add("YOU_WON", "Has ganado!");
		dictionary_es.Add("YOU_LOSE", "Has perdido!");
		dictionary_es.Add("PIRATE_BATTLE", "Batalla de piratas!!");
		dictionary_es.Add("YOUR_POWER", "Tu poder: ");
		dictionary_es.Add("ENEMY_POWER", "Poder enemigo: ");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetTextByCode(string code){
		if (GameManager.instance.currentLang == "en"){
			if (dictionary_en.ContainsKey(code)) return dictionary_en[code];
			else return code;
		} else {
			if (dictionary_es.ContainsKey(code)) return dictionary_es[code];
			else return code;
		}
	}
}
