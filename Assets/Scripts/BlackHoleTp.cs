using UnityEngine;
using System.Collections;

public class BlackHoleTp : MonoBehaviour {
	
	public GameObject secondBlackHole;

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.position.x > gameObject.transform.position.x)
			return;
		other.transform.position = secondBlackHole.transform.position;
	}
}
