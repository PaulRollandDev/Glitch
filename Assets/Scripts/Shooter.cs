using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;


	void Start() {
		
		projectileParent = GameObject.Find ("Projectile");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectile");
		}
		
	}
	
	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
