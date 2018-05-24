using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public AudioClip [] levelMusicChangeArray;
	private AudioSource audioSource;
	
	void Awake() {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont destory on load: " + name);
		//audioSource = GetComponent<AudioSource>();
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("playing: " + thisLevelMusic);
		
		if(thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		} else {
			Debug.LogError("No Music in Player");
		}
	}
	
	public void SetVolume(float volume) {
		audioSource.volume = volume;
	}
}//end
