using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	//public GameObject levelObjects;

	private GameManagerScript instance;
	private MoveCube player;

	private int level = 1;

	private Text fuelText;
	private Text levelText;

	// TODO: Länge des Levels anhand von LevelGenerator bestimmen
	public int levelLength = 0;
	private float playerSpeed = 0;

	
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();

		DontDestroyOnLoad (gameObject);
	}
	

//	void OnLevelWasLoaded(int index){
//		levelObjects = GameObject.FindGameObjectWithTag("LevelObjects");
//	}

//	public void LevelComplete() {
//		level++;
//		levelObjects.GetComponent<LevelGenerator>().JumpToLevel(level);
//	}


	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player") == null) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
		}

		playerSpeed = player.getCurrentSpeed();

//		if(Input.GetKey(KeyCode.R)) {
//			levelObjects.GetComponent<LevelGenerator>().JumpToLevel(level);
//		}
	}

	public float getPlayerPosition(){
		return player.transform.position.z;
	}

	public MoveCube getPlayer(){
		return player;
	}

	public int getLevelLength(){
		return levelLength;
	}

	public float getPlayerSpeed(){
		return playerSpeed;
	}

	public Text getfuelText(){
		return fuelText;
	}

	public void loadLevelSelectScene(){
		Debug.Log("Button 1 Clicked");
		Application.LoadLevel("LevelSelectScene");
	}
	
	public void loadConfigScene(){
		Application.LoadLevel("ConfigScene");
	}
}
