using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Transform target;


	// Use this for initialization
	void Start () {
	
		InvokeRepeating("FireProjectile", 5, 2);
	}
	
	// Update is called once per frame
	void Update () {

		target = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 look = target.transform.position - transform.position;
		look.z = 0;
		transform.LookAt(look);
	}

	void FireProjectile () {

		Vector3 projectileStartingPosition = new Vector3(this.transform.position.x + 2,transform.position.y,transform.position.z);

		GameObject projectile = PhotonNetwork.Instantiate("TurretProjectile", projectileStartingPosition, transform.rotation, 0);
		projectile.transform.LookAt(target.transform);

	}
}
