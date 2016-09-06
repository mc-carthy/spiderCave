using UnityEngine;
using System.Collections;

public class JumpingSpider : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;
	private float forceY = 300f;
	private const string ATTACK_BOOL = "attack";

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void Start () {
		StartCoroutine (Attack ());
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "ground") {
			anim.SetBool (ATTACK_BOOL, false);
		}
		if (trig.tag == "Player") {
			PlayerController.instance.Die ();
		}
	}

	private IEnumerator Attack () {
		yield return new WaitForSeconds (Random.Range(2f, 7f));
		forceY = Random.Range (250, 550);
		rb.AddForce(new Vector2(0, forceY));
		anim.SetBool (ATTACK_BOOL, true);
		yield return new WaitForSeconds (0.7f);
		StartCoroutine (Attack ());
	}
}
