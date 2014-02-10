using UnityEngine;
using System.Collections;

public class RunnerGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {

			PhotonNetwork.Disconnect();
			Application.LoadLevel (0);
		}
	}

	void OnExternalVelocity (){

	}
}
