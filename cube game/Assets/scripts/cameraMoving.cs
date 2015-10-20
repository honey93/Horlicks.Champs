using UnityEngine;
using System.Collections;

//attach to object to be moved
public class cameraMoving : MonoBehaviour {
	public Transform target;

	public float walkDistance=15.0F;
	public float height=7.0F;
	public float X_MouseSensitivity = 5.0f;
	public float Y_MouseSensitivity = 5.0f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	public float mouseSpeed = 0.5f;
	public float scrollSpeed=0.5f;

	private Quaternion _rotation1;
	private Vector3 _position;
	private Transform _myTransform;

	float x = 0.0f;
	float y = 0.0f;
	
	void Awake(){
		_myTransform = transform;
	}
	// INITIALIZATION
	void Start () {
		if (target == null) 
		{
			Debug.Log ("no target for camera");
		} 
		else 
		{
			Camerasetup ();
		}
		
	}
	//CALLED AFTER UPDATE PER FRFAME
	void LateUpdate(){
		if (target == null)
			return;
		
		HandlePlayerInput();
		UpdatePosition();
	}

	//SET UP INITIAL POSITION OF CAMERA
	public void Camerasetup(){
		_myTransform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);	
		_myTransform.LookAt (target);
	}

	//UPDATE CAMERA POSITION WITH USER INPUT THROUGH MOUSE
	public void UpdatePosition(){
		_rotation1 = Quaternion.Euler (y, x, 0);
		_position = _rotation1 * new Vector3 (0.0f, 0.0f, -walkDistance) + target.position;

		_myTransform.rotation = _rotation1;
		_myTransform.position = _position;
	}

	//GRAB USER INPUTS ON THE MOUSE
	public void HandlePlayerInput(){
		if (Input.GetMouseButton(1))
		{
			x += Input.GetAxis("Mouse X") * X_MouseSensitivity * mouseSpeed;
			y -= Input.GetAxis("Mouse Y") * Y_MouseSensitivity * mouseSpeed;
		}//rightclick ends
		
		if(Input.GetAxis("Mouse ScrollWheel") > 0) 
		{
			x += walkDistance * 0.02f;
			y -= 0.02f;
			
			walkDistance = Mathf.Clamp(walkDistance - Input.GetAxis("Mouse ScrollWheel")*scrollSpeed, distanceMin, distanceMax);
			
			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) 
			{
				walkDistance -=  hit.distance;
			}
		}//scrollup ends
		
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			x += walkDistance * 0.02f;
			y -= 0.02f;
			
			walkDistance = Mathf.Clamp(walkDistance - Input.GetAxis("Mouse ScrollWheel")*scrollSpeed, distanceMin, distanceMax);
			
			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) 
			{
				walkDistance -=  hit.distance;
			}
		}//scrolldown ends
	}
}