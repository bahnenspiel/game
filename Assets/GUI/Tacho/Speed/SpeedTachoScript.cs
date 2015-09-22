using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedTachoScript : MonoBehaviour {

	public Sprite[] tiles = new Sprite[11];
	private Image tacho;
	
	private GameManagerScript gm;
	private float playerSpeed = 0;


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
		playerSpeed = gm.getPlayerSpeed();
		var speedSlider = gm.getSpeed();
		//Debug.Log(">> SpeedTachoScript: Player Speed: " + playerSpeed);
		int speedRange = (int) ((80 * speedSlider) / 10);
		if (playerSpeed <= 0)
			tacho.sprite = tiles[0];
		for(int i = 0; i < 10; i++) {
			if(playerSpeed > i * speedRange) {
				tacho.sprite = tiles[i + 1];
			}
		}




			
	}
}
