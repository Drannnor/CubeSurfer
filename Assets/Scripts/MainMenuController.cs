using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
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
}