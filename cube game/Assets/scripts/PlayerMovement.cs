using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float maxSpeed=5.0f;
	public GameObject deathParticle;
	private Rigidbody rb;
	private Vector3 spawn;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		spawn = transform.position;
	}

	void FixedUpdate(){
		//vectore3 contents 3 float value(x,y,z) for rotation an movement in 3D plane
		Vector3 movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical"));
		if (rb.velocity.magnitude < maxSpeed) 
		{
			rb.AddRelativeForce (movement * speed);
		}
		if (transform.position.y < -2) 
		{
			die ();
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "enemy") 
		{
			die ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemy") 
		{
			die ();
		}
		if (other.gameObject.tag == "goal") 
		{
			gameManager.completeLevel();
		}
	}
	void die()
	{
		Instantiate (deathParticle, transform.position, Quaternion.Euler(270,0,0));
		new WaitForSeconds (3f);
		transform.position = spawn;
	}
}
