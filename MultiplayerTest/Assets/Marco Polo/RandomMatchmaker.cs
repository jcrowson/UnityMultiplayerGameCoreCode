using UnityEngine;
using System.Collections;

public class RandomMatchmaker : Photon.MonoBehaviour {
	
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom()
	{
		GameObject monster = PhotonNetwork.Instantiate("fpsController", Vector3.zero, Quaternion.identity, 0);

		FPSInputController fpsController = monster.GetComponent<FPSInputController>();
		fpsController.enabled = true;

		CharacterMotor motor = monster.GetComponent<CharacterMotor>();
		motor.enabled = true;

		//MouseLook mouseLook = monster.GetComponent<MouseLook>();
		//mouseLook.enabled = true;

		Camera cam = monster.GetComponentInChildren<Camera>();
		cam.enabled = true;

		MouseLook mouseLookCamera = monster.GetComponentInChildren<MouseLook>();
		mouseLookCamera.enabled = true;
	
	}

	void Update ()
	{

		if(Input.GetMouseButtonDown(0)) {
			GameObject crate = PhotonNetwork.Instantiate("cu_cat", Vector3.zero, Quaternion.identity, 0);
		}
	}
}
