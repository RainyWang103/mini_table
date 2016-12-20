<html><body><h1>403 Forbidden</h1>
Request forbidden by administrative rules.
</body></html>
our {

	public float speed;
	public Boundary yourboundary;
	public float tilt;
	
	void FixedUpdate()
	{
		float moveVertical = 0.0f;
		float moveHorizontal = 0.0f;
		if (Input.GetKey (KeyCode.H)) {
			moveVertical = 1.0f;
		} else if (Input.GetKey (KeyCode.N)) {
			moveVertical = -1.0f;}

		if (Input.GetKey (KeyCode.B)) {
			moveHorizontal = -1.0f;
		} else if (Input.GetKey (KeyCode.M)) {
			moveHorizontal = 1.0f;
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x , yourboundary.xmin , yourboundary.xmax),
				0.0f,
				Mathf.Clamp(rigidbody.position.z , yourboundary.zmin , yourboundary.zmax)
			);
		rigidbody.rotation = Quaternion.Euler (34.73f, 90.0f, rigidbody.velocity.x * -tilt);
	}
	
}
