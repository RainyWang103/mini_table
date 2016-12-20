using UnityEngine;
using System.Collections;

public class DestroyWhenTouch : MonoBehaviour {


	void OnTriggerEnter (Collider other) 
	{

		if (other.tag == "Ball") {
			Destroy (other.gameObject);
		}
	}
}
