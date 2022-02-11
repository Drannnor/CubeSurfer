using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void OpenLevelSelection() {
        //TODO
    }
}