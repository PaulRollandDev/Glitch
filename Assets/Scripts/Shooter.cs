using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;


	void Start() {
		animator = GetComponent<Animator>();
		// creates a parent if necessary 
		projectileParent = GameObject.Find ("Projectile");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectile");
		}
		SetMylaneSpawner();
	}
	
	void Update() {
			if(IsAttackerAheadInLane()) {
				animator.SetBool("isAttacking", true);
				} else {
				animator.SetBool("isAttacking", false);
	}
}

	void SetMylaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner spawner in spawnerArray) {
			if(spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + "no spawner in lane");
	}
	
	
	bool IsAttackerAheadInLane() {	
		//exit if no attacker in lane
		if (myLaneSpawner.transform.childCount <=0){
			return false;
		}
		//are attackers ahead
		foreach (Transform attackers in myLaneSpawner.transform) {
			if (attackers.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//attackers in lane but behind us
		return false;
	}
			
	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
