using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	public float timeAllowed = 10f;

	[SerializeField]
	private Slider slider;
	private GameObject player;

	private void Awake () {
		InitializeVariables ();
	}

	private void Update () {
		if (player != null) {
			if (timeAllowed > 0) {
				timeAllowed -= Time.deltaTime;
				slider.value = timeAllowed;
			} else {
				PlayerController.instance.Die ();
			}
		}
	}

	private void InitializeVariables () {
		player = GameObject.FindGameObjectWithTag ("Player");
		slider.minValue = 0f;
		slider.maxValue = timeAllowed;
		slider.value = slider.maxValue;
	}
}