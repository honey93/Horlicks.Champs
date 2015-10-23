using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float maxSpeed=9.0f;
	public GameObject deathParticle;
	private Rigidbody rb;
	private Vector3 spawn;
	public GameObject tall;
	public GameObject strong;
	public GameObject sharp;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		spawn = transform.position;
	}

	void FixedUpdate(){
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

		if (other.gameObject.name == "boosterT") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(2,5,0);
			rb.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
			gameObject.GetComponent<Renderer>().material.color = Color.grey;
			tall.SetActive(true);
		}
		if (other.gameObject.name == "boosterSt") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(2,5,0);
			rb.transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
			strong.SetActive(true);

			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		if (other.gameObject.name == "boosterSh") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(1,1,1);
			sharp.SetActive(true);

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
	public void AdjustMovHor(float newMov)
	{
		float moveHorizontal = newMov;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.AddForce (movement * speed);
	}
	
	public void AdjustMovVerti(float newMovVerti)
	{
		float moveVertical = newMovVerti;
		Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
}
