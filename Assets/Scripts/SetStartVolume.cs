using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
	musicManager = GameObject.FindObjectOfType<MusicManager>();
	if (musicManager){
		float volume = PlayPrefsManager.GetMasterVolume();
		musicManager.SetVolume (volume);
	} else {
	Debug.LogWarning("No Music Player Found");
	}
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
