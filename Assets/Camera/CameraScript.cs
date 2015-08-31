using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private GameManagerScript gm;
	public bool moveCameraBool = false;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		gameObject.GetComponent<Skybox>().material = gm.getSkybox();

	}
	
	// Update is called once per frame
	void Update () {
		if (moveCameraBool){
			float x = gameObject.transform.position.x;
			float y = gameObject.transform.position.y;
			float z = gameObject.transform.position.z;
			gameObject.transform.position.Set(x,y,z+10*Time.deltaTime);
			
		}
	}

	public void moveCamera(){
		moveCameraBool = true;
	}


}
