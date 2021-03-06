﻿using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {
	
	public float fuel = 100;

	public float steeringSpeed = 10f;
	public float jumpSpeed = 100f;
	
	
	private float minSpeed = 0, maxSpeed = 80;
	
	public float drivingSpeed;
	
	public AudioClip jumpSound;

	private Rigidbody rb;
	private SensorDataReceiver rcv;
	private GameManagerScript gm;


	private bool grounded = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rcv = GetComponent<SensorDataReceiver>();
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
	}

	void GameOver() {
		GetComponent<MeshRenderer>().enabled = false;

	}

	void FixedUpdate () {
		/*if(gameState.IsGameOver()) {
			rb.velocity = new Vector3();
			return;
		}*/
		if (Input.GetKey(KeyCode.UpArrow)){
			drivingSpeed += 10 * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.DownArrow)){
			drivingSpeed -= 10 * Time.deltaTime;
		}
		
		bool jump = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

		if(jump && grounded) {
			rb.AddForce(new Vector3(0,jumpSpeed,0));
			var pos = transform.position;
			pos.y += 0.5f;
			rb.MovePosition(pos);
			grounded = false;
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
		}
		Vector3 vel = rb.velocity;
		
		if (gm.isBikeControl()) {
			drivingSpeed = rcv.speed * 3.2f;
			vel.x = rcv.pitch * 2 * gm.getSensitivity();
		}
		else {
			
			if(Input.GetKey(KeyCode.LeftArrow)) {
				vel.x = -steeringSpeed;
			}
			if(Input.GetKey(KeyCode.RightArrow)) {
				vel.x = steeringSpeed;
			}
			if(Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
				vel.x = 0;
			}
		}
		
		drivingSpeed = Mathf.Min(drivingSpeed, maxSpeed * gm.getSpeed());
		drivingSpeed = Mathf.Max(drivingSpeed, minSpeed);
		
		vel.z = drivingSpeed;

		rb.velocity = vel;

		if (Input.GetKey(KeyCode.Escape)){
			gm.loadMainMenu();
		}
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
	/*	if(Input.GetKey(KeyCode.UpArrow)) {
			speed += drivingSpeed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.DownArrow)) {
			speed -= drivingSpeed * Time.deltaTime;
		

		fuel -= rcv.speed; 

	*/
	}

	public float getCurrentSpeed(){
		return drivingSpeed;
	}

	public void stopPlayer(){
		//speed = 0;
		steeringSpeed = 0;
		jumpSpeed = 0;
		drivingSpeed = 0;

		Camera.main.GetComponent<CameraScript>().moveCamera();
	}
}
