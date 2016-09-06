using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	public float force = 500f;

	private Animator anim;

	private void Awake () {
		anim = GetComponent<Animator> ();
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		Debug.Log ("collision");
		if (trig.tag == "Player") {
			trig.gameObject.GetComponent<PlayerController> ().Bounce (force);
			StartCoroutine (AnimateBounce ());
		}
	}

	private IEnumerator AnimateBounce () {
		anim.Play ("bounceUp");
		yield return new WaitForSeconds (0.5f);
		anim.Play ("bounceDown");
	}
}
