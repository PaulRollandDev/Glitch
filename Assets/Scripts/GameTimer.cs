using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float LevelSeconds = 100; 
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManger;
	private GameObject winLable;

	// Use this for initialization
	void Start () {
	slider = GetComponent<Slider>();
	levelManger = GameObject.FindObjectOfType<LevelManager>();
	audioSource = GetComponent<AudioSource>();
	FindYouWinMessage ();
	winLable.SetActive(false);
	}

	void FindYouWinMessage ()
	{
		winLable = GameObject.Find ("You Win");
		if (!winLable) {
			Debug.LogWarning ("No Win Lable present!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / LevelSeconds;
		
		bool timeIsUp = Time.timeSinceLevelLoad >= LevelSeconds;
		if ( timeIsUp && !isEndOfLevel) {
			HandleWinCondition ();
	
		}
	}

	void HandleWinCondition ()
	{
		DestoryAllTaggedObjects();
		audioSource.Play ();
		winLable.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	void DestoryAllTaggedObjects() {
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject taggedObject in taggedObjectArray) {
			Destroy(taggedObject);
		}
	}
	
	
	void LoadNextLevel() {
		levelManger.LoadNextLevel();
	}
	
}
