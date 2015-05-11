using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	public float steeringSpeed = 8f;
	public float jumpSpeed = 1000f;
	public float drivingSpeed = 10f;

	private float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = 0;
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		Vector3 vel = rb.velocity;
		vel.z = speed;

		if(Input.GetKey(KeyCode.LeftArrow)) {
			vel.x = -steeringSpeed;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			vel.x = steeringSpeed;
		}

		rb.velocity = vel;

		if(Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(new Vector3(0,jumpSpeed,0));
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)) {
			speed += drivingSpeed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.DownArrow)) {
			speed -= drivingSpeed * Time.deltaTime;
		}

	}
}
