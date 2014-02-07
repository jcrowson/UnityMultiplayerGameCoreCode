using UnityEngine;
using System.Collections;

public class DefendingPlayerGUI : MonoBehaviour {

	public Transform placementPlanesRoot;
	public Material hoverMat;
	public LayerMask placementLayerMask;

	private Material originalMat;
	private GameObject lastHitObj;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();


		if (Physics.Raycast(ray,out hit,1000.0f,placementLayerMask))
		{
			if(lastHitObj)
			{
				lastHitObj.renderer.material = originalMat;
			}
			
			lastHitObj = hit.collider.gameObject;
			originalMat = lastHitObj.renderer.material;
			lastHitObj.renderer.material = hoverMat;
		}
		else 
		{
			if(lastHitObj)
			{
				lastHitObj.renderer.material = originalMat;
				lastHitObj = null;
			}
		}

		if(Input.GetMouseButtonDown(0) && lastHitObj) {
			
			if(lastHitObj.tag == "placementPlane_Open")
			{
				GameObject turret = PhotonNetwork.Instantiate ("turret", lastHitObj.transform.position, Quaternion.identity, 0);
				Vector3 currentPosition = turret.transform.position;
				//currentPosition.y = currentPosition.y + 0.6f;
				//turret.transform.position = currentPosition;
				turret.transform.Rotate(270, 0, 0);
			}
		}
	}
}
