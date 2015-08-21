using UnityEngine;
using System.Collections;

public class ProgressSliderScript : MonoBehaviour {

	private GameManagerScript gm = null;
	private UnityEngine.UI.Slider slider = null;
	private float playerPosition = 0;
	
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		slider = gameObject.GetComponent<UnityEngine.UI.Slider>();
	}
	

	// Update is called once per frame
	void Update () {
		playerPosition = gm.getPlayerPosition();
		//Debug.Log (">> ProgressSliderScript: Player Position: " + playerPosition);
		updateSlider(playerPosition);
	}


	private void updateSlider(float playerPosition){
		float sliderValue = playerPosition / (gm.getLevelLength() * 20);
		Debug.Log (">> ProgressSliderScript: Slider Value: " + sliderValue);
		slider.value = sliderValue;
	}
}
