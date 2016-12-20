using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float zmax,zmin,xmax,xmin;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary myboundary;
	public float tilt;

	void FixedUpdate()
	{
		float moveVertical = 0.0f;
		float moveHorizontal = 0.0f;
		moveVertical = Input.GetAxis ("Vertical");
		moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x , myboundary.xmin , myboundary.xmax),
				0.0f,
				Mathf.Clamp(rigidbody.position.z , myboundary.zmin , myboundary.zmax)
			);
		rigidbody.rotation = Quaternion.Euler (34.73f, 90.0f, rigidbody.velocity.x * -tilt);
	}
	
}
