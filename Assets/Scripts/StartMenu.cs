using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	GameManager GM;
	
	void Awake () {
		GM = GameManager.Instance;
		GM.OnStateChange += HandleOnStateChange;

	}
	
	void Start () {

	}
	public void ChangeState() {
		GM.SetGameState (GameState.GAME);
	}
	public void HandleOnStateChange ()
	{
		Application.LoadLevel("Gameplay");
		//Invoke("LoadLevel", 1f);
	}
	

	
	
}