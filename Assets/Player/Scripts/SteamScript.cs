using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {

	public GameObject[] steam;

	private MoveCube player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCube>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.getCurrentSpeed() > 0) {
			activateSteam(true);
		} else{
			activateSteam(false);
		}
	}

	void activateSteam(bool val){
		for(int i = 0; i < 2; i++) {
			steam[i].SetActive(val);
			ParticleSystem ps = steam[i].GetComponent<ParticleSystem>();
			ps.emissionRate = player.getCurrentSpeed() * 10;
		}
		
	}


}
