using UnityEngine;
using System.Collections;
using System.IO;

public class LevelSelectButtonScript : MonoBehaviour {

	private int numLevels;
	// Use this for initialization
	void Awake () {
		numLevels = Directory.GetFiles(Application.dataPath + "/Resources/Levels", "*.txt").Length;


	}
	
	// Update is called once per frame
	void Update () {

	}
}
