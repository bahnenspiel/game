using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	private bool triggered = false;

	void OnTriggerEnter(Collider collider) {
		if (triggered)
			return;
		else
			triggered = true;

	/*	MoveCube player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
		player.stopPlayer();
	*/
		
		GameManagerScript gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		gm.LevelCompleted();
	}
}
