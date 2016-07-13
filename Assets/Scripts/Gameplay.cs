using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public void Pause()
	{
			GameManager.Instance.OnPause ();
	}
}
