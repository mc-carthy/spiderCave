using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	[SerializeField]
	private float moveForce = 20f, jumpForce = 600f, maxVelocity = 4f;
	private Rigidbody2D rb;
	private Animator anim;
	private bool isOnGround = true;

	private void Awake () {
		InitializeVariables ();
		MakeInstance ();
	}

	private void FixedUpdate () {
		WalkKeyboard ();
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "ground") {
			isOnGround = true;
		}
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "bouncer") {
			isOnGround = true;
		}
	}

	private void InitializeVariables () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void Die () {
		Debug.Log ("Player Dead");
		GameplayController.instance.PlayerDied ();
		Destroy (gameObject);
	}

	public void Bounce (float force) {
		//if (isOnGround) {
			isOnGround = false;
			rb.velocity = new Vector2 (0, force);
		//}
	}

	private void WalkKeyboard () {
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (rb.velocity.x);
		float h = Input.GetAxisRaw ("Horizontal");

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
