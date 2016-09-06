using UnityEngine;
using System.Collections;

public class TimeAir : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "Player") {
			if (gameObject.name == "air") {
				GameObject.FindObjectOfType<AirTimer> ().airCapacity += 15f;
			} else if (gameObject.name == "time") {
				GameObject.FindObjectOfType<LevelTimer> ().timeAllowed += 15f;
			}
			Destroy (gameObject);
		}
	}
}
