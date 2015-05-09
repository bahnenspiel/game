using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if(Input.GetKey(KeyCode.LeftArrow)) {
			pos.x -= 10f * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			pos.x += 10f * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.UpArrow)) {
			pos.y += 10f * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			pos.y -= 10f * Time.deltaTime;
		}

		transform.position = pos;
	}
}
