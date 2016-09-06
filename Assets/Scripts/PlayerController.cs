using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float moveForce = 20f, jumpForce = 600f, maxVelocity = 4f;
	private Rigidbody2D rb;
	private Animator anim;
	private bool isOnGround = true;

	private void Awake () {
		InitializeVariables ();
	}

	private void FixedUpdate () {
		WalkKeyboard ();
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "ground") {
			isOnGround = true;
		}
	}

	private void InitializeVariables () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void WalkKeyboard () {
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (rb.velocity.x);
		float h = Input.GetAxisRaw ("Horizontal");

		/*
		Vector3 scale = transform.localScale;

		if (h == 1) {
			if (vel < maxVelocity) {
				if (isOnGround) {
					forceX = moveForce;
				} else {
					forceX = moveForce * 5;
				}
			}
			scale.x = 1f;
		}
		if (h == -1) {
			if (vel < maxVelocity) {
				forceX = -moveForce;
			}
			scale.x = -1f;
		}

		if (h != 0) {
			anim.SetBool ("walk", true);
		} else {
			anim.SetBool ("walk", false);
		}
		*/

		if (h > 0) {
			if (vel < maxVelocity) {
				forceX = moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;
			anim.SetBool ("walk", true);
		} else if (h < 0) {
			if (vel < maxVelocity) {
				forceX = -moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;
			anim.SetBool ("walk", true);
		} else if (h == 0) {
			anim.SetBool ("walk", false);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isOnGround) {
				isOnGround = false;
				forceY = jumpForce;
			}
		}

		rb.AddForce(new Vector2(forceX, forceY));
	}
}
