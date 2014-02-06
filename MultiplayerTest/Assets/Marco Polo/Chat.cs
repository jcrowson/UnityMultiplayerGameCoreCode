﻿using UnityEngine;
using System.Collections;

public class Chat : MonoBehaviour {

	private bool textFieldEnabled = false;
	private bool userHasHitReturn = false;
	private string textFieldText = "";
	public string chatHistoryText = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Return)) {
			textFieldEnabled = true;
		}
	}
	void OnGUI () {

		//Chat History
		GUI.SetNextControlName("chatHistory");
		chatHistoryText = GUI.TextArea(new Rect(0,0, 200, 200), chatHistoryText);

		if (Event.current.type == EventType.KeyDown && Event.current.character == '\n') {
			chatHistoryText = chatHistoryText + "\n" +textFieldText;
			textFieldEnabled = false;
			textFieldText = "";
		}

		//Single Chat Box
		if (textFieldEnabled) {
			GUI.SetNextControlName("chatBox");
			GUI.FocusControl("chatBox");
			textFieldText = GUI.TextField(new Rect((Screen.width)/2,(Screen.height)/2, 400, 50), textFieldText, 140);
		}
	}

	[RPC]
	void Marco()
	{
		Debug.Log("Marco");
		chatHistoryText = "James Nudged You!";
		//update the view
		Update ();
	
	}
	[RPC]
	void Polo()
	{
		Debug.Log("Polo");
	}
}
