using UnityEngine;
using System.Collections;

public class DefendingPlayerGUI : MonoBehaviour {

	public Transform placementPlanesRoot;
	public Material hoverMat;
	public LayerMask placementLayerMask;

	private Material originalMat;
	private GameObject lastHitObj;
	private int objectToBuild;

	public GUIStyle guiStyle;
	public static bool isRunner;
	private bool isBuilding;
	
	// Use this for initialization
	void Start () {

		isBuilding = false;
	
	}

	void OnGUI () {

		GUI.contentColor = Color.black;
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());


		if (isRunner)
		{
			Screen.showCursor = false;

		}
		else 
		{
			Screen.showCursor = true;


			GUI.contentColor = Color.white;
			
			//Build Menu
			GUI.Box(new Rect(10,10,100,90), "Build Menu");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "Build Turret")) {
				//Application.LoadLevel(1);
				objectToBuild = 0;
				Debug.Log("Building a turret");
				isBuilding = true;
			}
			
			// Make the second button.c
			if(GUI.Button(new Rect(20,70,80,20), "Build Trap Door")) {
				//Application.LoadLevel(2);
				objectToBuild = 1;
				Debug.Log("Building a trap door");
				isBuilding = true;
			}
		}
	}
	
	void Update () {

		if (isRunner)
		{



		}
		else
		{

			if(isBuilding) {

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				
				
				if (Physics.Raycast(ray, out hit, 1000.0f, placementLayerMask))
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
						if(objectToBuild == 0)
						{
							GameObject turret = PhotonNetwork.Instantiate ("SimpleTurret", lastHitObj.transform.position, Quaternion.identity, 0);
							Vector3 currentPosition = turret.transform.position;
							turret.transform.Rotate(0, 0, 0);
						}
						else
						{
							GameObject turret = PhotonNetwork.Instantiate ("cu_cat", lastHitObj.transform.position, Quaternion.identity, 0);
							Vector3 currentPosition = turret.transform.position;
							turret.transform.Rotate(270, 0, 0);
						}
					}
				}
				
				if(Input.GetMouseButtonDown(1)) {

					isBuilding = false;
					if(lastHitObj)
					{
						lastHitObj.renderer.material = originalMat;
						lastHitObj = null;
					}
				}
			}
		}
	}
}
