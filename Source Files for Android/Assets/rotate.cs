using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rotate : MonoBehaviour {
	public Transform milk;
	public Transform burger;
	public Transform donut;
	public Transform cake;
	public Transform icecream;


	void start() {


	}
	// Update is called once per frame
	void Update () 
	{
		milk.transform.Rotate (Vector3.down, 20* Time.deltaTime);
		icecream.transform.Rotate (Vector3.right, 50* Time.deltaTime);
		burger.transform.Rotate (Vector3.right, 50* Time.deltaTime);
		donut.transform.Rotate (Vector3.left, 50* Time.deltaTime);
		cake.transform.Rotate (Vector3.left, 50* Time.deltaTime);
		donut.transform.RotateAround(milk.transform.position, Vector3.up, 35 * Time.deltaTime);
		icecream.transform.RotateAround(milk.transform.position, Vector3.up, 35 * Time.deltaTime);
		burger.transform.RotateAround(milk.transform.position, Vector3.up, 35 * Time.deltaTime);
		cake.transform.RotateAround(milk.transform.position, Vector3.up, 35 * Time.deltaTime);
	

	}
}
	