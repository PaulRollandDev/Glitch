using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider;

		
	public LevelManager levelManager;
	private MusicManager musicManager;

	void Start () {
		 musicManager = GameObject.FindObjectOfType<MusicManager>();
		 volumeSlider.value = PlayPrefsManager.GetMasterVolume();
		 difficultySlider.value = PlayPrefsManager.GetDifficulty();
	}
	
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void SetDefault() {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
	
	public void SaveAndExit() {
		PlayPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayPrefsManager.SetDifficulty(difficultySlider.value);

		levelManager.LoadLevel("01a Start");
	}
}//end 
