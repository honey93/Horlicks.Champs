using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	public static int currentScore;
	public static int highScore;

	public static int currentLevel = 0;
	public static int unlockedLevel;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void completeLevel()
	{
		if (currentLevel < 2) {
			currentLevel++;
			Application.LoadLevel (currentLevel);
		} else 
		{
			print("u win");
		}
	}
}
