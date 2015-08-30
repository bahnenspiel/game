using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelTachoScript : MonoBehaviour {

	public Sprite[] tiles = new Sprite[11];
	private Image tacho;
	
	private GameManagerScript gm;
	private float currentTime = 0;
	private float maxTime = 0;
	private float restartTime = 4;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		tacho = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		updateTacho();
	}

	private void updateTacho(){
		currentTime = gm.getCurrentTime();
		maxTime = gm.getLevelTime();


		float temp = (maxTime - currentTime) / maxTime;
		int tileNumber = (int)(temp * tiles.Length);

		tileNumber = Mathf.Max(tileNumber, 0);

		tacho.sprite = tiles[tileNumber];

		if (currentTime > maxTime) {
			gm.destroyPlayer();
			restartTime -= Time.deltaTime;
			Text gameOverLabel = GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<Text>();
			Text restartLabel = GameObject.FindGameObjectWithTag("RestartLabel").GetComponent<Text>();
			
			gameOverLabel.text = "Out of Energy!";
			restartLabel.text = "Restart in " + (int)restartTime;

			if (restartTime <= 0){
				gm.loadLevel();
			}
		}

			
	}
}
