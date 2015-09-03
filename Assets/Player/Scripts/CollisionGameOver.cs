﻿using UnityEngine;
using System.Collections;

public class CollisionGameOver : MonoBehaviour {



	void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Goal"){

			GameManagerScript gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
			gm.doRestart = true;
			gm.setGameOverLabel("Level Failed!");


		}
	}
}
