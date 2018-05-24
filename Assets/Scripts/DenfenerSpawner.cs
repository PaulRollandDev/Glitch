using UnityEngine;
using System.Collections;

public class DenfenerSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;
	
	void Start() {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if(!parent) {
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown() {
		Vector2 rawPos = CalulateWorldPointsOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if (starDisplay.UseStars(defenderCost) ==  StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log("Insufficiebt stars to spawn");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRoation = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRoation) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}
	
	
	Vector2 CalulateWorldPointsOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		
		return worldPos;
	}
}
