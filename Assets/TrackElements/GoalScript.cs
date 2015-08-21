using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		Camera.main.GetComponent<GameState>().LevelComplete();

		MoveCube player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
		player.stopPlayer();
		
		GameManagerScript gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
//		gm.LevelComplete();
	}
}
