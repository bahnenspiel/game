using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	private GameManagerScript instance;
	private MoveCube player = null;

	private int level = 1;

	// TODO: Länge des Levels anhand von LevelGenerator bestimmen
	public int levelLength = 0;
	private float playerSpeed = 0;

	
	void Start()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad (gameObject);
	}


	// Update is called once per frame
	void Update () {
		if(player != null) {
			playerSpeed = player.getCurrentSpeed();
		}
	}



	private void findPlayer(){
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		
		if (playerObject != null){
			player = playerObject.GetComponent<MoveCube>();
		}
	}

	public float getPlayerPosition(){
		if (player)
			return player.transform.position.z;
		else
			return 0;
	}

	public MoveCube getPlayer(){
		return player;
	}

	public int getLevelLength(){
		return levelLength;
	}

	public int getLevelNumber(){
		return level;
	}

	public float getPlayerSpeed(){
		return playerSpeed;
	}

	public void loadLevel(){
		player = null;
		Application.LoadLevel("TrackLoaderScene");
	}

	public void levelLoaded(){
		findPlayer();
	}

	public void LevelCompleted(){
		level++;

		if (level > Resources.LoadAll("Levels/", typeof(TextAsset)).Length){
			level = 1;
			Application.LoadLevel("WinScene");
		} else {
			loadLevel();
		}
	}

}
