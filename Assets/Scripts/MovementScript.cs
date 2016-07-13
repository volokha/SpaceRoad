using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float enginePower = 15f;
	public float maxSpeed = 5f;
	public float rotationSpeed = 4f;
	public ParticleSystem firePs;

	Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if (Input.GetAxis ("Vertical") > 0) {
			//rb.velocity = transform.up * Input.GetAxis ("Vertical") * enginePower + new Vector3(0, Physics2D.gravity.y, 0);
			rb.AddForce(transform.up * Input.GetAxis ("Vertical") * enginePower);
		}
		firePs.startLifetime = 0.2f * Input.GetAxis ("Vertical");

		transform.Rotate (0,0, -Input.GetAxis("Horizontal") * rotationSpeed);
	}

	void OnCollisionStay2D(Collision2D coll) {
		if(coll.gameObject.layer == 8){
			transform.parent = coll.transform ; 
		}
		else {
			transform.parent = null;
		}
	}
	void OnCollisionExit2D(Collision2D coll) {
		if(coll.gameObject.layer == 8) {
			transform.parent = null; ; 
		}
	}
}
