using UnityEngine;
using System.Collections;

public class RandomMatchmaker : Photon.MonoBehaviour {

	private PhotonView myPhotonView;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

		if (PhotonNetwork.isMasterClient) {

			Screen.showCursor = true;
			if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
			{
				if (GUILayout.Button("Spawn Cat"))
				{
					//Spawn a cat selected.
				}
				else if (GUILayout.Button("Spawn Crate"))
				{
					//Spawn a crate selected.
				}
			}
		}
		else {

			Screen.showCursor = false;

		}
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

		if (PhotonNetwork.isMasterClient) {


		}
		else {

			Vector3 playerSpawnPosition = new Vector3(0,10,0);

			GameObject player = PhotonNetwork.Instantiate("fpsController", playerSpawnPosition, Quaternion.identity, 0);
			
			FPSInputController fpsController = player.GetComponent<FPSInputController>();
			fpsController.enabled = true;
			
			CharacterMotor motor = player.GetComponent<CharacterMotor>();
			motor.enabled = true;
			
			Camera cam = player.GetComponentInChildren<Camera>();
			cam.enabled = true;
			
			MouseLook mouseLookCamera = player.GetComponentInChildren<MouseLook>();
			mouseLookCamera.enabled = true;
			
			Chat chatScript = player.GetComponent<Chat>();
			chatScript.enabled = true;
			
			myPhotonView = player.GetComponent<PhotonView>();

		}
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {

			//GameObject turret = PhotonNetwork.Instantiate ("turret", Vector3.zero, Quaternion.identity, 0);
		}
	}
}
