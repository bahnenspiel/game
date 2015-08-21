using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private bool gameOver = false;

	public ParticleSystem explosion;
	public GameObject expl;

	public void EndGame() {
		gameOver = true;
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		//GameObject.Instantiate(expl, player.transform.position, player.transform.rotation);
	}
}
