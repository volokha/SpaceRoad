using UnityEngine;
using System.Collections;

public class ForceTest : MonoBehaviour {

	Rigidbody2D rb;
	
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce ( new Vector2 (10f, 0));
	}
	void FixedUpdate () {
		rb.AddForce ( new Vector2 (10f, 0));
	}
}
