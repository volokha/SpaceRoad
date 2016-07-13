using UnityEngine;
using System.Collections;

public class DestroyOnCollide : MonoBehaviour {

	public GameObject rocketExplosion;
	// Use this for initialization
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Asteroid") {
			gameObject.SetActive(false);
			Instantiate (rocketExplosion, transform.position, transform.rotation);

			GameManager gm;
			gm = GameManager.Instance;
			gm.OnStateChange += HandleOnStateChange;
			gm.SetGameState(GameState.MAIN_MENU);
		}
	}
	public void HandleOnStateChange () {
		Invoke ("LoadLevel", 1f);

	}
	
	public void LoadLevel() {
		Destroy (gameObject);
		Application.LoadLevel("StartMenu");
	}
}