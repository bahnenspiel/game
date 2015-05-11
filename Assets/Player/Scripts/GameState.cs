using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private bool gameOver = false;

	public ParticleSystem explosion;

	public void EndGame() {
		gameOver = true;
		explosion.Play();
		BroadcastMessage("GameOver", null, SendMessageOptions.DontRequireReceiver);
	}

	public bool IsGameOver() {
		return gameOver;
	}
}
