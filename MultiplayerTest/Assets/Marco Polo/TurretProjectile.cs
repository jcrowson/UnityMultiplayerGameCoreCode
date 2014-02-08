using UnityEngine;
using System.Collections;

public class TurretProjectile : MonoBehaviour {

	public float projectileSpeed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.rigidbody.velocity = transform.forward * projectileSpeed;
		//transform.rigidbody.AddForce(transform.forward);
	}
}
