using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirTimer : MonoBehaviour {

	public float airCapacity = 10f;

	[SerializeField]
	private Slider slider;
	private GameObject player;
	private float airRate = 1f;

	private void Awake () {
		InitializeVariables ();
	}

	private void Update () {
		if (player != null) {
			if (airCapacity > 0) {
				airCapacity -= airRate * Time.deltaTime;
				slider.value = airCapacity;
			} else {
				PlayerController.instance.Die ();
			}
		}
	}

	private void InitializeVariables () {
		player = GameObject.FindGameObjectWithTag ("Player");
		slider.minValue = 0f;
		slider.maxValue = airCapacity;
		slider.value = slider.maxValue;
	}
}
