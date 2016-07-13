using UnityEngine;
using System.Collections;

public class AsteroidBeltGenerator : MonoBehaviour {

	public float speed = 1f;

	public float maxAngularVelocity = 20f;

	public float deltaSpawnTime = .9f;

	public float leftMargin = -0.1f;
	public float rightMargin = 1.1f;

	public float asteroidJerk = 0.1f;

	public Rigidbody2D asteroid;

	public LayerMask beltLayer;
	
	void Start () {
		GenerateBelt ();
		StartCoroutine (GeneratingBelt());
	}

	void Update() {
		Vector2 posToCheckTop = Camera.main.ViewportToWorldPoint(new Vector2(rightMargin, 1f));

		if (!Physics2D.OverlapCircle(posToCheckTop, 1f, beltLayer))
			CreateAsteroid(new Vector3(rightMargin, Random.Range(1f, 1f - asteroidJerk), 10));


		Vector2 posToCheckBottom = Camera.main.ViewportToWorldPoint(new Vector2(rightMargin, 0f));
		
		if (!Physics2D.OverlapCircle(posToCheckBottom, 1f, beltLayer))
			CreateAsteroid(new Vector3(rightMargin, Random.Range(0f, asteroidJerk), 10));
	}

	IEnumerator GeneratingBelt() {
		while (true) {
			//Верхний пояс
			CreateAsteroid(new Vector3(leftMargin, Random.Range(1f, 1f - asteroidJerk), 10));

			//Нижний пояс
			CreateAsteroid(new Vector3(leftMargin, Random.Range(0f, asteroidJerk), 10));

			yield return new WaitForSeconds(deltaSpawnTime);
		}
	}

	void GenerateBelt() {
		
		Vector2 startPoint = Camera.main.WorldToViewportPoint(new Vector2(0, 0));
		Vector2 endPoint = Camera.main.WorldToViewportPoint(new Vector2(speed * deltaSpawnTime, 0));
		Vector2 range = endPoint - startPoint;

		for (float positionX = leftMargin + 0.05f; positionX <= rightMargin; positionX += range.x) {
			//Верхний пояс
			CreateAsteroid(new Vector3(positionX, Random.Range(1f, 1f - asteroidJerk), 10));

			//Нижний пояс
			CreateAsteroid(new Vector3(positionX, Random.Range(0, asteroidJerk), 10));
		}
	}

	void CreateAsteroid(Vector3 worldPos) {
		worldPos = Camera.main.ViewportToWorldPoint(worldPos);

		Rigidbody2D asteroidClone = (Rigidbody2D) Instantiate(asteroid, worldPos, transform.rotation);
		asteroidClone.velocity = new Vector3(speed, 0, 0);
		asteroidClone.angularVelocity = Random.Range(- maxAngularVelocity, maxAngularVelocity);
		asteroidClone.transform.SetParent (transform);
	}
}
