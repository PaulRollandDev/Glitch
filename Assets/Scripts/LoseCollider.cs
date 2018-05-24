using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManger;
	// Use this for initialization
	void Start () {
		levelManger = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D () {
		levelManger.LoadLevel("03b Lose");
	}
	
}
