#pragma strict

//Placement Plane Items

var placementPlanesRoot : Transform;
var hoverMat : Material;
var placementLayerMask : LayerMask;
private var originalMat : Material;
private var lastHitObj : GameObject;

var buildPanelOpen : boolean = true;

//Building Arrays
//var allStructures : GameObject[];
//private var structureIndex : int = 0;

function Start () {
	//structureIndex = 0;
	//UpdateGUI();
}

function Update () {

	if(buildPanelOpen)
	{
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		
		if(Physics.Raycast (ray,hit,1000,placementLayerMask))
		{
			if(lastHitObj)
			{
				lastHitObj.renderer.material = originalMat;
			}
			
			lastHitObj = hit.collider.gameObject;
			originalMat = lastHitObj.renderer.material;
			lastHitObj.renderer.material = hoverMat;
			
		}
		else {
			if(lastHitObj)
			{
				lastHitObj.renderer.material = originalMat;
				lastHitObj = null;
			}
		}
		
		if(Input.GetMouseButtonDown(0) && lastHitObj) {
		
			if(lastHitObj.tag == "placementPlane_Open")
			{
				Debug.Log("left Clicked on a placement plane!");
				//GameObject player = PhotonNetwork.Instantiate("fpsController", playerSpawnPosition, Quaternion.identity, 0);
				//GameObject turret = PhotonNetwork.Instantiate ("turret", Vector3.zero, Quaternion.identity, 0);
				//var player : GameObject = PhotonNetwork.Instantiate("PlayerPrefab", Vector3.Zero, Quaternion.identity, 0);
			}
		}
		
	}//endBuildPanelOpen
}