using UnityEngine;
using System.Collections;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SensorDataReceiver : MonoBehaviour
{

	public int listenPort = 11000;
	UdpClient listenerClient;
	Thread listenerThread;

	public float speed = 0;
	public float pitch = 0;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnEnable(){
		Debug.Log ("enabled");
		listenerThread = new Thread (Listen);
		listenerThread.Start ();
	}

	void OnDisable() {
		CleanupConnection();
		Debug.Log ("disabled");
	}

	void Listen ()
	{
		listenerClient = new UdpClient (listenPort);
		IPEndPoint groupEP = new IPEndPoint (IPAddress.Any, listenPort);

		try {
			while (true) {
				byte[] messageBytes = listenerClient.Receive (ref groupEP);
				String messageText = Encoding.UTF8.GetString(messageBytes);
				if(messageText.StartsWith("p")){
					messageText = messageText.Substring(1);
				    //Debug.Log("pitch update: "+messageText);
					pitch = float.Parse(messageText) - 1.45f;
				}
				else if(messageText.StartsWith("rpm")){
					messageText = messageText.Substring(3);
					//Debug.Log("rpm update: " + messageText);
					var sp = float.Parse(messageText);
					if(sp != 0)
						speed = sp * 0.1f;
					else
						speed = speed * 0.8f;
				
				}
				else if(messageText.StartsWith("btn")){
					Debug.Log("btn update");
				}
			}
			
		} catch (Exception e) {
			Console.WriteLine (e.ToString ());
		} finally {
			listenerClient.Close ();
		}
	}

	void OnDestroy(){
		CleanupConnection();
		Debug.Log ("destroy");
	}

	void OnApplicationQuit(){
		Debug.Log ("Cleanup on quit");
		CleanupConnection ();
	}

	void CleanupConnection(){
		if(listenerClient!=null)
			listenerClient.Close ();
		if(listenerThread!=null)
			listenerThread.Abort();
	}
}


