using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private TMP_ColorGradient lockedGradient;
    [SerializeField] private TMP_ColorGradient unlockedGradient;
    private const string LevelButton = "LevelButton";

    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    private void ChangeLevelButtonColors() {
        var index = GameManager.GM.GetCurrentLevelIndex();
        var levelSelectMenu = levelSelect.transform;
        for (int i = 0; i < levelSelectMenu.childCount; i++) {
            var levelButton = levelSelectMenu.GetChild(i);
            if (!levelButton.CompareTag(LevelButton)) return;
            var gradient = i <= index ? unlockedGradient : lockedGradient;
            ChangeGradient(levelButton, gradient);
        }
    }

    private void ChangeGradient(Transform levelButton, TMP_ColorGradient gradient) {
        var text = levelButton.GetChild(0).GetComponent<TMP_Text>();
        if (text != null) {
            text.colorGradientPreset = gradient;
        } else {
            Debug.Log("ERROR: No textMeshPro Found");
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenLevelSelection() {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        ChangeLevelButtonColors();
    }

    public void GoBackToMenu() {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void OpenLevel(int levelIndex) {
        GameManager.GM.OpenLevel(levelIndex);
    }
}