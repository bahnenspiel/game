using UnityEngine;
using System.Collections;

public class CollisionGameOver : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		Camera.main.GetComponent<GameState>().EndGame();
	}
}
