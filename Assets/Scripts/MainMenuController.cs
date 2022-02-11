using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void OnEnable() {
        var index = GameManager.GM.GetCurrentLevelIndex();
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void OpenLevelSelection() {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }
    
    public void GoBackToMenu() {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void OpenLevel(int levelIndex) {
        GameManager.GM.OpenLevel(levelIndex);
    }
}