using UnityEngine;
using System.Collections;

public class TextureChangeScript : MonoBehaviour {

	private GameManagerScript gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		gameObject.GetComponent<Renderer>().material = gm.getMaterial();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
