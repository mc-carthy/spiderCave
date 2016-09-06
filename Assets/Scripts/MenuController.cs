using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void GoToLevelSelect () {
		SceneManager.LoadScene ("levelSelect", LoadSceneMode.Single);
	}
}
