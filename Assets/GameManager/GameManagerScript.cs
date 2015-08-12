using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public GameObject levelObjects;

	private GameManagerScript instance;
	private MoveCube player;

	private int level = 1;

	private Text fuelText;
	private Text levelText;

	
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad (gameObject);

		InitGame();
	}

	void OnLevelWasLoaded(int index){
		// level++;
		InitGame ();
	}


	void InitGame(){
		
	}
	
	public void LevelComplete() {
		level++;
		levelObjects.GetComponent<LevelGenerator>().JumpToLevel(level);
	}


	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player") != null) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
			fuelText = GameObject.Find("FuelText").GetComponent<Text>();
			levelText = GameObject.Find ("LevelText").GetComponent<Text>();
			
			fuelText.text = "Treibstoff " + player.fuel;
			levelText.text = "Level " + level;
			
		}
		if(Input.GetKey(KeyCode.R)) {
			levelObjects.GetComponent<LevelGenerator>().JumpToLevel(level);
		}
	}

	public MoveCube getPlayer(){
		return player;
	}

	public Text getfuelText(){
		return fuelText;
	}
}
