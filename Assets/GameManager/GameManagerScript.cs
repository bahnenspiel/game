using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public GameObject explosion;

	private GameManagerScript instance;
	private MoveCube player = null;
	public int textureChange = 3;
	private int level = 1;
	public int levelLength = 0;
	public int levelTime = 0;
	private float playerSpeed = 0;

	private float currentTime = 0;
	private float restartTime = 4;
	
	private bool gameOver = false;
	public bool doRestart = false;

	public Material[] mats = new Material[0];
	public Material[] skyboxes = new Material[0];

	
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

		if (currentTime > levelTime) {
			doRestart = true;
			setGameOverLabel("Out of Energy!");
		}

		if (doRestart){
			destroyPlayer();
			restartTime -= Time.deltaTime;
			Text restartLabel = GameObject.FindGameObjectWithTag("RestartLabel").GetComponent<Text>();


			//gameOverLabel.text = "Out of Energy!";
			restartLabel.text = "Restart in " + (int)restartTime;
			
			if (restartTime <= 0){
				restartTime = 4;
				loadLevel();
				setGameOverLabel("");
				restartLabel.text = "";
				doRestart = false;

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
		setLevelLabel();
		gameOver = false;
		currentTime = 0;
		findPlayer();
	}


	private void setLevelLabel(){
		GameObject label = GameObject.FindGameObjectWithTag("LevelLabel");
		
		if (label != null){
			label.GetComponent<Text>().text = "Level " + level;
		}
	}

	public void setGameOverLabel(string text){
		Text gameOverLabel = GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<Text>();
		gameOverLabel.text = text;
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

	public Material getMaterial(){
		return mats[(level-1)/textureChange];
	}

	public Material getSkybox(){
		return skyboxes[(level-1)/textureChange];
	}


}
 