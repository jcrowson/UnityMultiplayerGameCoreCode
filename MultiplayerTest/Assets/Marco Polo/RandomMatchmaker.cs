using UnityEngine;
using System.Collections;

public class RandomMatchmaker : Photon.MonoBehaviour {

	private PhotonView myPhotonView;
	public static bool isRunner;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
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

		if (isRunner)
		{
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

			//myPhotonView = player.GetComponent<PhotonView>();

		}
		else 
		{
			//Is playing as defender
		}
	}

	void Update ()
	{

	}

	void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log("OnPhotonPlayerDisconnected: " + player);
	}
}
