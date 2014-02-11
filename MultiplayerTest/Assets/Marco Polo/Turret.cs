using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject turretProjectile;
	public Transform myTarget;
	public Transform bulletStartingPosition;

	private float reloadTime = 1f;
	private float turnSpeed = 5f;
	private float firePauseTime = 0.25f;
	public Transform turretTurn;

	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;
	private float aimError = 0.0f;

	public Camera mainCamera;
	public Camera turretCamera;
	
	// Use this for initialization
	void Start () {
	
		//mainCamera.enabled = false;
		//turretCamera.enabled = true;
	}
	
	// Update is called once per frame

	void Update () {
	
		if(myTarget){
			if(Time.time >= nextMoveTime){
				CalculateAimPosition(myTarget.position);
				turretTurn.rotation = Quaternion.Lerp(turretTurn.rotation, desiredRotation, Time.deltaTime*turnSpeed);
				
			}
			
			if(Time.time >= nextFireTime){
				FireProjectile();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			nextFireTime = Time.time+(reloadTime*0.5f);
			myTarget = other.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.transform == myTarget){
			myTarget = null;
		}
	}

	void CalculateAimPosition(Vector3 targetPos){
		Vector3 aimPoint = new Vector3(targetPos.x - transform.position.x + aimError, targetPos.y - transform.position.y + aimError, targetPos.z - transform.position.z + aimError);
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	

	void FireProjectile() {

		nextFireTime = Time.time + reloadTime;
		nextMoveTime = Time.time + firePauseTime;
		Instantiate(turretProjectile, bulletStartingPosition.position, bulletStartingPosition.rotation);

	}
}
