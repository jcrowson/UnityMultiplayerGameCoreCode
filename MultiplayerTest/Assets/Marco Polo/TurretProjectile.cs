using UnityEngine;
using System.Collections;

public class TurretProjectile : MonoBehaviour {

	public float mySpeed = 10;
	public float force = 10;
	public float myRange = 5;
	private float myDist;
	private float velocityToHitPlayerBack = 15.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		 transform.Translate(Vector3.forward * Time.deltaTime * mySpeed);
		myDist += Time.deltaTime * mySpeed;
		if(myDist >= myRange){
			Destroy(gameObject);
		}
	}


	void OnTriggerEnter(Collider other) {

		//whatever it hits, delete it.
		Destroy(gameObject);

		if (other.tag == "Player") {

			Debug.Log ("hit the player, knock back!");
			Vector3 dir = (other.transform.position - transform.position).normalized;
			CharacterMotor charMotor = other.GetComponent<CharacterMotor>();
			//charMotor.SetVelocity(dir*velBack);
			charMotor.SetVelocity(dir * velocityToHitPlayerBack);
		}
		else {
			Debug.Log ("hit something else!");
		}
	}


	void OnCollisionEnter(Collision collision){
		//next - check if we have collided with anything but player/enemy
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy"){
			//do nothing - or apply damage maybe?
			Debug.Log ("");
		}
		else{
			Destroy(gameObject);
		}
	}

}