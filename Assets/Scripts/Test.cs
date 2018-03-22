using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//test volume
		//print ("Volume" + PlayPrefsManager.GetMasterVolume());
		//PlayPrefsManager.SetMasterVolume(0.3f);
		print ("Volume" + PlayPrefsManager.GetMasterVolume());
		//test level
		print ("Level" + PlayPrefsManager.IsLevelUnlocked (2));
		PlayPrefsManager.UnlockLevel (2);
		print ("Level" + PlayPrefsManager.IsLevelUnlocked (2));
		// test difficulty 
		print ("Difficulty" + PlayPrefsManager.GetDifficulty());
		PlayPrefsManager.SetDifficulty(0.2f);
		print ("Difficulty" + PlayPrefsManager.GetDifficulty());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
