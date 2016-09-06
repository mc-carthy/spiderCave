using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public void OnPointerDown (PointerEventData data) {
		if (gameObject.name == "leftButton") {
			PlayerController.instance.SetMoveLeft (true);
		} else if (gameObject.name == "rightButton") {
			PlayerController.instance.SetMoveLeft (false);
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (gameObject.name == "leftButton" || gameObject.name == "rightButton") {
			PlayerController.instance.StopMove ();
		}
	}
}
