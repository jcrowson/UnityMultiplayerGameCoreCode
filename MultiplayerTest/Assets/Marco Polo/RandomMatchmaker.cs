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
			Screen.showCursor = false;

		}
		else {

			Screen.showCursor = true;

			if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
			{
				if (GUILayout.Button("Spawn Cat"))
				{

				}
			}	
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

			GameObject monster = PhotonNetwork.Instantiate("fpsController", Vector3.zero, Quaternion.identity, 0);
			
			FPSInputController fpsController = monster.GetComponent<FPSInputController>();
			fpsController.enabled = true;
			
			CharacterMotor motor = monster.GetComponent<CharacterMotor>();
			motor.enabled = true;
			
			Camera cam = monster.GetComponentInChildren<Camera>();
			cam.enabled = true;
			
			MouseLook mouseLookCamera = monster.GetComponentInChildren<MouseLook>();
			mouseLookCamera.enabled = true;
			
			Chat chatScript = monster.GetComponent<Chat>();
			chatScript.enabled = true;
			
			myPhotonView = monster.GetComponent<PhotonView>();
		}
		else {
			//load the birds eye component


		}

	}

	void Update ()
	{
		Vector3 mousePos=new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

		if (Input.GetMouseButtonDown (0)) {
			Vector3 wordPos;
			Ray ray=Camera.main.ScreenPointToRay(mousePos);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,1000f)) {
				wordPos=hit.point;
			} else {
				wordPos=Camera.main.ScreenToWorldPoint(mousePos);
			}
			GameObject cat = PhotonNetwork.Instantiate ("cu_cat", wordPos, Quaternion.identity, 0);		
		}
	}
}
