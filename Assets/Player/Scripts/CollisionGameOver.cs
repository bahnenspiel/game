using UnityEngine;
using System.Collections;

public class CollisionGameOver : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Goal"){
			Camera.main.GetComponent<GameState>().EndGame();
		}
	}
}
