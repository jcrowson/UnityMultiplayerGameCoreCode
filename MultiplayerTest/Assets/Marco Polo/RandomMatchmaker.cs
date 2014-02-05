using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

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
		GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
		//CharacterControl controller = monster.GetComponent<CharacterControl>();
		//controller.enabled = true;
		//CharacterCamera camera = monster.GetComponent<CharacterCamera>();
		//camera.enabled = true;
		FPSInputController fpsController = monster.GetComponent<FPSInputController>();
		fpsController.enabled = true;

		CharacterMotor motor = monster.GetComponent<CharacterMotor>();
		motor.enabled = true;

		PlatformInputController platformInputController = monster.GetComponent<PlatformInputController>();
		platformInputController.enabled = true;

		MouseLook mouseLook = monster.GetComponent<MouseLook>();
		mouseLook.enabled = true;

		Camera playerCamera = monster.GetComponent<Camera>();
		playerCamera.enabled = true;
	}
	
}
