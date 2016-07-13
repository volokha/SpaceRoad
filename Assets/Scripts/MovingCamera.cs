using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	public Transform rocket;

	void LateUpdate () {
		if (!rocket)
			return;

		Vector3 rocketViewportPosition = Camera.main.WorldToViewportPoint(rocket.position);

		if (rocketViewportPosition.x >= 0.5f)
			transform.position = new Vector3 (rocket.transform.position.x, 0, -10);
	}
}