using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {

	public void LoadGame () {
		SceneManager.LoadScene ("main");
	}

	public void BackToMenu () {
		SceneManager.LoadScene ("menu");
	}
}
