using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float maxSpeed=5.0f;
	public GameObject deathParticle;
	private Rigidbody rb;
	private Vector3 spawn;
	private int score;
	private bool sharp;
	public Text countText;
	public GameObject ins;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		spawn = transform.position;
		score = 0;
		setCountText ();
		sharp = false;
	}

	void FixedUpdate(){
		//vectore3 contents 3 float value(x,y,z) for rotation an movement in 3D plane
		Vector3 movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical"));
		if (rb.velocity.magnitude < maxSpeed) 
		{
			if(sharp==true){
				rb.AddRelativeForce (movement * speed*2);
			}
			else
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
		if (other.gameObject.name == "boostT") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(2,5,0);
			rb.transform.localScale += new Vector3(0, 1, 0);
			score++;
			setCountText ();
		}
		if (other.gameObject.name == "boostSt") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(2,5,0);
			rb.transform.localScale += new Vector3(1, 0, 1);
			score++;
			setCountText ();
		}
		if (other.gameObject.name == "boostSh") 
		{
			other.gameObject.SetActive(false);
			rb.velocity = new Vector3(2,5,0);
			gameObject.GetComponent<Renderer>().material.color = Color.green;
			score++;
			sharp=true;
			setCountText ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "goal") {
			if (score == 3)
			{
				gameManager.completeLevel ();
			}
			else
			{
				ins.SetActive (true);

			}
		}
	}

	void die()
	{
		Instantiate (deathParticle, transform.position, Quaternion.Euler(270,0,0));
		new WaitForSeconds (3f);
		transform.position = spawn;
		Application.LoadLevel(Application.loadedLevel);
	}

	void setCountText()
	{
		countText.text="Score: " + score.ToString();
	}

}
