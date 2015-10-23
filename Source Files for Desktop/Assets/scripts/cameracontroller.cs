using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {
	
	private GameObject player;
	
	private Vector3 offset;
	
	void Start ()
	{
		player=GameObject.Find("player");
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}