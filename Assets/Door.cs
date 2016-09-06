using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public static Door instance;
	[HideInInspector]
	public int collectablesCount;

	private BoxCollider2D box;
	private Animator anim;

	private void Awake () {
		MakeInstance ();
		box = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "Player") {

		}
	}

	public void DecrementCollectables () {
		collectablesCount--;
		if (collectablesCount <= 0) {
			StartCoroutine (OpenDoor ());
		}
	}

	private IEnumerator OpenDoor () {
		anim.Play ("doorOpen");
		yield return new WaitForSeconds (0.7f);
		box.isTrigger = true;
	}
}
