using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GameLangManager : MonoBehaviour {

	public static GameLangManager instance = null;

	private string[] langCodes = {"en", "es"};
	private int currentLangIndex;

	private Dictionary<string, string> translations;

	void Awake() {
		if (instance == null) instance = this;
		else if (instance != this) Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		translations = new Dictionary<string, string>();

		SetCurrentLanguage(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextCurrentLanguage(){
		currentLangIndex++;
		if (currentLangIndex > langCodes.Length-1) currentLangIndex = 0;

		ChangeDictionary();
	}

	public void SetCurrentLanguage(int index) {
		if (index >= 0 && index < langCodes.Length){
			currentLangIndex = index;
			
			ChangeDictionary();
		}
	}

	public string GetCurrentLanguage(){
		return langCodes[currentLangIndex];
	}

	public string GetLanguageByIndex(int i){
		return langCodes[i];
	}

	public string GetTextByCode(string code) {
		if (translations.ContainsKey(code)) return translations[code];
		else return code;
	}

	private void ChangeDictionary(){
		translations.Clear();

		var dictionary = JSON.Parse(Resources.Load<TextAsset> ("GameTexts_"+langCodes[currentLangIndex]).text);
		for (int i = 0; i < dictionary["translations"].Count; i++){
			foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject)dictionary["translations"][i])
			{
				translations.Add(kvp.Key, kvp.Value.Value);
			}
		}
	}
}
