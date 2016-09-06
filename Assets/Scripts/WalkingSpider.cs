using UnityEngine;
using System.Collections;

public class WalkingSpider : MonoBehaviour {

	public float speed = 1f;

	private Rigidbody2D rb;
	[SerializeField]
	private Transform startPos, endPos;
	private bool collision;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate () {
		Move ();
		ChangeDirection ();
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") { 
			PlayerController.instance.Die ();
		}
	}

	private void Move () {
		rb.velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}

	private void ChangeDirection () {
		collision = Physics2D.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("ground"));
		if (!collision) {
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}
	}
}