using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float minX = -35f, maxX = 100f;

	private Transform player;
	private float offsetY;

	private void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		offsetY = transform.position.y - player.position.y;
	}

	private void Update () {
		if (player != null) {
			Vector3 temp = transform.position;
			temp.x = Mathf.Clamp (player.position.x, minX, maxX);
			temp.y = player.position.y + offsetY;
			transform.position = temp;
		}
	}
}
