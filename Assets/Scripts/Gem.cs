using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	private void Start () {
		if (Door.instance != null) {
			Door.instance.collectablesCount++;
		}
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (Door.instance != null) {
			if (trig.tag == "Player") {
				Door.instance.DecrementCollectables ();
				Destroy (gameObject);
			}
		}
	}
}
