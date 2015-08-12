using UnityEngine;
using System.Collections;

public class AnimatePlayerMovement : MonoBehaviour {

	public GameObject afterburner1;
	public GameObject afterburner2;

	float speed = 8.0f;
	float acc = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float x = this.transform.position.x +Time.deltaTime * 2 * 3;
		//float y = this.transform.position.y + Time.deltaTime * 3;
		//float z = this.transform.position.z + Time.deltaTime * 3 * 3;
		//this.transform.position = new Vector3 (x,y,z);

		this.transform.position = transform.position + this.transform.forward * speed * Time.deltaTime;

		if (this.transform.position.z >= 100){
			this.transform.RotateAround(transform.position, transform.forward, -8 * Time.deltaTime);
			this.transform.RotateAround(Vector3.zero, transform.up, 1.5f * Time.deltaTime);
			acc += 22 * Time.deltaTime;
			speed += acc * Time.deltaTime;

			afterburner1.GetComponent<ParticleSystem>().startColor = new Color(0x1A, 0x50, 0x85, 0xFF);
			afterburner2.GetComponent<ParticleSystem>().startColor = new Color(0x1A, 0x50, 0x85, 0xFF);

			afterburner1.GetComponent<ParticleSystem>().startSpeed = 50;
			afterburner2.GetComponent<ParticleSystem>().startSpeed = 50;
		
		}
	
	}
}
