using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.ChangeScene(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
