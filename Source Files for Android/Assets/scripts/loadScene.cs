using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {
	public void nextScene(string nameOfScene)
	{
		Application.LoadLevel (nameOfScene);
	}
	public void exitScene()
	{
		Application.Quit();
	}
}
