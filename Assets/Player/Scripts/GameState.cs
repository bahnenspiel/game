using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private bool gameOver = false;

	public void EndGame() {
		gameOver = true;
		SendMessage("GameOver", null, SendMessageOptions.DontRequireReceiver);
	}

	public bool IsGameOver() {
		return gameOver;
	}
}
