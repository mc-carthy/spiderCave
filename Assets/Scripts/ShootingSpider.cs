using UnityEngine;
using System.Collections;

public class ShootingSpider : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;

	void Start () {
		StartCoroutine(Attack ());
	}

	private IEnumerator Attack () {
		yield return new WaitForSeconds(Random.Range(2f, 7f));
		Instantiate (bullet, transform.position, Quaternion.identity);
		StartCoroutine (Attack ());
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "Player") {
			PlayerController.instance.Die ();
		}
	}
}
