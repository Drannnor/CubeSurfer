using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuController : MonoBehaviour {

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