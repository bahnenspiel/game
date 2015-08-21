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
		//Debug.Log(">> SpeedTachoScript: Player Speed: " + playerSpeed);

		if (playerSpeed <= 0)
			tacho.sprite = tiles[0];
		if (playerSpeed > 0 && playerSpeed <= 10)
			tacho.sprite = tiles[1];
		if (playerSpeed > 10 && playerSpeed <= 20)
			tacho.sprite = tiles[2];
		if (playerSpeed > 20 && playerSpeed <= 30)
			tacho.sprite = tiles[3];
		if (playerSpeed > 30 && playerSpeed <= 40)
			tacho.sprite = tiles[4];
		if (playerSpeed > 40 && playerSpeed <= 50)
			tacho.sprite = tiles[5];
		if (playerSpeed > 50 && playerSpeed <= 60)
			tacho.sprite = tiles[6];
		if (playerSpeed > 60 && playerSpeed <= 70)
			tacho.sprite = tiles[7];
		if (playerSpeed > 70 && playerSpeed <= 80)
			tacho.sprite = tiles[8];
		if (playerSpeed > 80 && playerSpeed <= 90)
			tacho.sprite = tiles[9];
		if (playerSpeed > 90)
			tacho.sprite = tiles[10];


			
	}
}
