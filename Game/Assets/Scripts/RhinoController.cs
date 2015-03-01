using UnityEngine;
using System.Collections;

public class RhinoController : MonoBehaviour {

	public float jumpForce = 70.0f;
	public float runForce = 80.0f;
	public float forwardMovementSpeed = 4.0f;
	public Transform groundCheckTransform;
	
	private bool grounded = true;
	
	public LayerMask groundCheckLayerMask;
	
	//Animator animator;

	void FixedUpdate () {
		bool jumpingActive = Input.GetButton("Fire1");
		if (jumpingActive && grounded)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			grounded = false;
		}

		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = forwardMovementSpeed;
		rigidbody2D.velocity = newVelocity;
		//UpdateGroundedStatus();
	}

	//void UpdateGroundedStatus() {
		//1
		//grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		
		//2
		//animator.SetBool("grounded", grounded);
	//}
	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.contacts[0].otherCollider.gameObject.CompareTag("Ground")) grounded = true;
		//if (collision.contacts [0].otherCollider.gameObject.CompareTag ("Barrels"))
	//		Destroy (this.gameObject);
	//	isAlive = false;
	}
}
