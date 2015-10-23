using UnityEngine;
using System.Collections;

public class patrol : MonoBehaviour {
	public Transform[] patrolPoints;
	public float moveSpeed;
	private Transform _myTransform;
	private int currentPoint;
	void Awake(){
		_myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		_myTransform.position = patrolPoints [0].position;
		currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(_myTransform.position == patrolPoints[currentPoint].position)
		{
			currentPoint++;
		}
		if(currentPoint>=patrolPoints.Length)
		{
			currentPoint=0;
		}
		_myTransform.position = Vector3.MoveTowards(_myTransform.position,patrolPoints[currentPoint].transform.position,moveSpeed*Time.deltaTime);
	}
}
