using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	public static int currentLevel = 1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void completeLevel()
	{
		if (currentLevel != 3) {
			currentLevel++;
			Application.LoadLevel (currentLevel);
		} else {

			Application.LoadLevel (currentLevel - 3);
		}
	}
}
