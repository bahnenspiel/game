using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfigSceneScript : MonoBehaviour {

	private GameManagerScript gm;

	public Slider speedSlider;
	public Slider sensitivitySlider;
	public Toggle bikeControlToggle;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backToMenu(){
		gm.setSensitivity(sensitivitySlider.value);
		gm.setSpeed(speedSlider.value);
		gm.setIsBikeControl(bikeControlToggle.isOn);

		Application.LoadLevel("MenuScene");
	}
}
