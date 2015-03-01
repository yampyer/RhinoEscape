using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	public AudioSource evilLaughAudio;
	float forwardMovementSpeed = -2.0f;
	bool deadRhino = false;
	Animator animator;

	void OnCollisionEnter(Collision colision) {
		if (colision.gameObject.CompareTag("Player")) deadRhino = true;
	}

	void OnTriggerEnter(Collider colision)
	{
		if (colision.gameObject.CompareTag("Player")){
			deadRhino = true;
		}
	}

	void Start () {
		animator = GetComponent<Animator>();
	}

	void AdjustEvilLaughSound() {
		evilLaughAudio.enabled = deadRhino;
	}

	void FixedUpdate() {
		if (deadRhino) {
			animator.SetBool ("deadRhino", deadRhino);
		} //else rigidbody.AddForce(new Vector3(forwardMovementSpeed,0,0));
		AdjustEvilLaughSound();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
