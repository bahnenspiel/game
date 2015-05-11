using UnityEngine;
using System.Collections;

public class CollisionGameOver : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Game Over");
	}
}
