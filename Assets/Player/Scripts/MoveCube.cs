using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {
	
	public float fuel = 100;

	public float steeringSpeed = 10f;
	public float jumpSpeed = 100f;
	
	
	public float minSpeed = 0, maxSpeed = 80;
	
	public float drivingSpeed;
	
	public bool bikeControls = false;

	//private float speed;
	private Rigidbody rb;
	private GameState gameState;
	private SensorDataReceiver rcv;


	private bool grounded = false;

	// Use this for initialization
	void Start () {
		gameState = Camera.main.GetComponent<GameState>();
		//speed = 0;
		rb = GetComponent<Rigidbody>();
		rcv = GetComponent<SensorDataReceiver>();
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
		}
		Vector3 vel = rb.velocity;
		
		if (bikeControls) {
			drivingSpeed = rcv.speed;
			vel.x = rcv.pitch;
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
		
		drivingSpeed = Mathf.Min(drivingSpeed, maxSpeed);
		drivingSpeed = Mathf.Max(drivingSpeed, minSpeed);
		
		vel.z = drivingSpeed;

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
