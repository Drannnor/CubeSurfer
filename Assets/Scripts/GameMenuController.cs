using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour {
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject HUD;

    private void Start() {
        GameManager.GM.SetGameMenuController(this);
    }

    public void LoadLevel(string levelName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        HUD.SetActive(true);
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        HUD.SetActive(false);
    }

    public void ShowDeathScreen() {
        HUD.SetActive(false);
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    public void RetryLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ShowVictoryScreen() {
        pauseScreen.SetActive(false);
        victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }
}