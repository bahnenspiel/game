﻿using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	public float steeringSpeed = 10f;
	public float jumpSpeed = 100f;
	public float drivingSpeed = 10f;

	private float speed;
	private Rigidbody rb;
	private GameState gameState;


	private bool grounded = false;

	// Use this for initialization
	void Start () {
		gameState = Camera.main.GetComponent<GameState>();
		speed = 0;
		rb = GetComponent<Rigidbody>();
	}

	void GameOver() {
		GetComponent<MeshRenderer>().enabled = false;
	}

	void FixedUpdate () {
		if(gameState.IsGameOver()) {
			rb.velocity = new Vector3();
			return;
		}
		if(Input.GetKeyDown(KeyCode.Space) && grounded) {
			rb.AddForce(new Vector3(0,jumpSpeed,0));
			var pos = transform.position;
			pos.y += 0.5f;
			rb.MovePosition(pos);
			grounded = false;
		}
		Vector3 vel = rb.velocity;
		vel.z = speed;

		if(Input.GetKey(KeyCode.LeftArrow)) {
			vel.x = -steeringSpeed;
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			vel.x = steeringSpeed;
		}
		if(Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			vel.x = 0;
		}

		rb.velocity = vel;


	}

	void OnCollisionEnter(Collision collision) {
		if(collision.collider.tag == "Ground") {
			grounded = true;
		}
	}

	/*void OnCollisionExit(Collision collision) {
		if(collision.collider.tag == "Ground") {
			grounded = false;
		}
	}*/
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)) {
			speed += drivingSpeed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.DownArrow)) {
			speed -= drivingSpeed * Time.deltaTime;
		}

	}
}
