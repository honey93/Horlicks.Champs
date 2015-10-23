using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {
	public float dalayTime;
	// Use this for initialization
	void Start () {
		StartCoroutine (GO ());
	}
	IEnumerator GO()
	{
		while(true)
		{
//			Animation.Play();
			yield return new WaitForSeconds(3f);
		}
	}
}
