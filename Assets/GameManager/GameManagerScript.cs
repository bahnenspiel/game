using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public GameObject explosion;

	private GameManagerScript instance;
	private MoveCube player = null;

	private int level = 1;
	public int levelLength = 0;
	public int levelTime = 0;
	private float playerSpeed = 0;

	private float currentTime = 0;

	private bool gameOver = false;

	
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

			currentTime += Time.deltaTime;
			
			if (Input.GetMouseButtonDown(1)) {
				loadLevel();
			}
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

	public void destroyPlayer(){
		if (gameOver){
			return;
		} else {
			gameOver = true;
			Vector3 pos = player.transform.position;
			Camera.main.transform.parent = null;
			player.gameObject.SetActive(false);
			GameObject.Instantiate(explosion, pos, new Quaternion());
		}

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

	public float getCurrentTime(){
		return currentTime;
	}

	public float getLevelTime(){
		return levelTime;
	}

	public void loadLevel(){
		player = null;
		Application.LoadLevel("TrackLoaderScene");
	}

	public void levelLoaded(){
		gameOver = false;
		currentTime = 0;
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
