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
		CharacterControl controller = monster.GetComponent<CharacterControl>();
		controller.enabled = true;
		CharacterCamera camera = monster.GetComponent<CharacterCamera>();
		camera.enabled = true;
	}
	
}
