using UnityEngine;
using System.Collections;

public class PlayPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty_key";
	const string LEVEL_KEY = "level_unloacked_";

	public static void SetMasterVolume (float volume){
	if (volume >= 0f && volume <= 1f){ 
		PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
	} else {
		Debug.LogError("Master Volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount -1) {
			PlayerPrefs.SetInt (LEVEL_KEY +  level.ToString(), 1); // use 1 for true
		} else {
		 Debug.LogError ("Unlock Error Not in build order");
		 }
	}
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString()); 
		bool isLevelUnlocked = (levelValue == 1);
		
		if (level <= Application.levelCount -1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Unlock Error Not in build order");
			return false;
		}	
	}

	public static void SetDifficulty (float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) { 
			PlayerPrefs.SetFloat (DIFF_KEY, difficulty);
		}else{
			Debug.LogError ("Difficlty out of range");
		}
	}
	
	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat(DIFF_KEY);
	}
	
}//end
