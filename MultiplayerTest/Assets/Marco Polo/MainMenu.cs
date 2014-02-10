using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		Screen.showCursor = true;

		GUI.contentColor = Color.white;
			
		GUI.Box(new Rect(50,50,250,250), "Running Game v0.1");
			
		if(GUI.Button(new Rect(70,100,200,70), "Play as Runner")) 
		{
			Application.LoadLevel (1);
			RandomMatchmaker.isRunner = true;
			DefendingPlayerGUI.isRunner = true;
		}
		if(GUI.Button(new Rect(70,190,200,70), "Play as Defender")) 
		{
			Application.LoadLevel (1);
			RandomMatchmaker.isRunner = false;
			DefendingPlayerGUI.isRunner = false;
		}
	}
}
