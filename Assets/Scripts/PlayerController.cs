using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	[SerializeField]
	private float moveForce = 20f, jumpForce = 600f, maxVelocity = 4f, forceX, forceY;
	private Rigidbody2D rb;
	private Animator anim;
	[SerializeField]
	private Button jumpButton;
	private bool isOnGround = true;
	private bool moveLeft, moveRight;

	private void Awake () {
		InitializeVariables ();
		MakeInstance ();
		jumpButton.onClick.AddListener (() => Jump ());
	}

	private void Update () {
		//KeyboardInput ();
		TouchInput ();
	}

	private void FixedUpdate () {
		Move ();
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

	public void SetMoveLeft (bool moveLeft) {
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}

	public void StopMove () {
		this.moveLeft = false;
		this.moveRight = false;
	}

	public void Die () {
		GameplayController.instance.PlayerDied ();
		Destroy (gameObject);
	}

	public void Bounce (float force) {
			isOnGround = false;
			rb.velocity = new Vector2 (0, force);
	}

	public void Jump () {
		if (isOnGround) {
			isOnGround = false;
			forceY = jumpForce;
		}
	}

	// The below methods need drying

	private void KeyboardInput () {
		forceX = 0f;
		forceY = 0f;

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
			Jump ();
		}
	}

	private void TouchInput () {
		forceX = 0f;
		float vel = Mathf.Abs (rb.velocity.x);

		if (moveRight && !moveLeft) {
			if (vel < maxVelocity) {
				forceX = moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;
			anim.SetBool ("walk", true);		
		} else if (moveLeft && !moveRight) {
			if (vel < maxVelocity) {
				forceX = -moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;
			anim.SetBool ("walk", true);
		} else {
			anim.SetBool ("walk", false);
		}
	}

	private void Move () {
		rb.AddForce(new Vector2(forceX, forceY));
		forceY = 0f;
	}
}
