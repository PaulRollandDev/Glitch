using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

private StarDisplay starDisplay;

public int starCost = 10;

void Start () {
	starDisplay = GameObject.FindObjectOfType<StarDisplay>();
}

// used as defender tag
public void AddStars (int amount) {
	starDisplay.AddStars(amount);

    }
	
}
