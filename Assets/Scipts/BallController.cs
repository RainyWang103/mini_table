using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	public float initialSpeed;
	private PlayerController player;
	private ApponentController apponent;
	private GameController masterControl;
	private Vector3 relation = new Vector3();

	void Start () 
	{
		//Get GameController
		GameObject masterControlObject = GameObject.FindWithTag ("GameController");
		if (masterControlObject != null) {masterControl = masterControlObject.GetComponent<GameController>();}
		//Get Player
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) {player = playerObject.GetComponent<PlayerController>();}
		//Get Aponent
		GameObject apponentObject = GameObject.FindWithTag ("Apponent");
		if (apponentObject != null) {apponent = apponentObject.GetComponent<ApponentController>();}

		//Ball initial settings
		Vector2 Direction = Random.insideUnitCircle;
		Vector3 firstMove = new Vector3 (Direction.x, 0.0f, Direction.y);
		rigidbody.velocity = firstMove * initialSpeed;
		Debug.Log (transform.position);
	}
	
	
	void FixedUpdate()
	{
		rigidbody.velocity = rigidbody.velocity;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "UPDOWN") {
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 0.0f, -rigidbody.velocity.z);
		} else if (other.tag == "LERI") {
			rigidbody.velocity = new Vector3 (-rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
		} else if (other.tag == "PlayerGate") {
			masterControl.UpdateScore("Apponent");
		} else if (other.tag == "ApponentGate") {
			masterControl.UpdateScore("Player");
		}

		else
		{
			if (other.tag == "Player"){relation = player.rigidbody.velocity;}
			else if (other.tag == "app") {relation = apponent.rigidbody.velocity;}
			rigidbody.velocity = new Vector3 (-rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
			rigidbody.velocity += relation;
		}
	
	}
}
