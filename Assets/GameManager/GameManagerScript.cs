using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

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
		level++;
		InitGame ();
	}


	void InitGame(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
		fuelText = GameObject.Find("FuelText").GetComponent<Text>();
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
	}


	// Update is called once per frame
	void Update () {
		fuelText.text = "Treibstoff " + player.fuel;
		levelText.text = "Level " + level;
	}

	public MoveCube getPlayer(){
		return player;
	}

	public Text getfuelText(){
		return fuelText;
	}
}
