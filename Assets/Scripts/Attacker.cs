using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between apperances")]
	public float spawnTime;
	
	private float currentSpeed;
	private GameObject currentTraget;

	private Animator animator;


	void Start() {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTraget) {
			animator.SetBool ("isAttacking", false);
	 }
	}
	
	void OnTriggerEnter2D() {
	}
	
	public void SetSpeed (float speed) {
	currentSpeed = speed;
	}
	
	// called from the animator at time of actual blow
	public void StrikeCurrentTarget (float damage) {
		if(currentTraget){
		Health health = currentTraget.GetComponent<Health>();
		if (health){
			health.DealDamage(damage);
	  }
	 }
	}
	
	public void Attack (GameObject obj) {
	currentTraget = obj;
	}	
}//end
