using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private Button resumeGame;

	private void Awake () {
		MakeInstance ();
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void PauseGame () {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeGame.onClick.RemoveAllListeners ();
		resumeGame.onClick.AddListener (() => ResumeGame ());
	}

	public void ResumeGame () {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}

	public void GoToMenu () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	public void PlayerDied () {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		resumeGame.onClick.RemoveAllListeners ();
		resumeGame.onClick.AddListener (() => RestartGame ());
	}
}
