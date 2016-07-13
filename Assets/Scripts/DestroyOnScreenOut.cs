using UnityEngine;
using System.Collections;

public class DestroyOnScreenOut : MonoBehaviour {

	void Update() {
		Vector2 objPosition = Camera.main.WorldToViewportPoint(transform.position);

		if (objPosition.x > 1.3f || objPosition.x < -0.11f)
			Destroy(gameObject);

	}
}
