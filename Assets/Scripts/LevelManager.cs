using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextlevel;
	
	void Start() {
	if (autoLoadNextlevel <= 0){
		Debug.Log("level auto load disabled, use a postive number representing seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextlevel);
	}
}
	
	public void LoadLevel(string name) {
		Debug.Log("New Level Load" + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Game Quit");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
}//end