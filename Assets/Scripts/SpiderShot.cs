using UnityEngine;
using System.Collections;

public class SpiderShot : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "Player") {
			PlayerController.instance.Die ();
		}
		if (trig.tag != "spider") {
			Destroy (gameObject);
		}
	}
}
