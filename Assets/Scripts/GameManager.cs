using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour{
    private const string MAX_LEVEL_INDEX = "MaxLevelReached";
    private const string CURRENT_LEVEL_NAME = "CurrentLevel";
    [Header("GameManager")] public static GameManager GM;

    [SerializeField] private bool ResetProgress = false;

    private GameMenuController _gameMenuController;
    [SerializeField] private LevelInfo[] levelInfoList;

    private int _currentLevelIndex;
    private void Awake(){
        if (GM != null)
            Destroy(GM);
        else
            GM = this;

        DontDestroyOnLoad(GM);
        
        if (PlayerPrefs.HasKey(MAX_LEVEL_INDEX)) {
            _currentLevelIndex = PlayerPrefs.GetInt(MAX_LEVEL_INDEX);

        } else {
            _currentLevelIndex = 0;
            PlayerPrefs.SetInt(MAX_LEVEL_INDEX, _currentLevelIndex);
        }
        
        if(ResetProgress)PlayerPrefs.DeleteAll();
        
    }

    public void SetGameMenuController(GameMenuController gmc) {
        _gameMenuController = gmc;
    }

    public GameMenuController GetGameMenuController() {
        return _gameMenuController;
    }

    public void LevelFinished() {
        _gameMenuController.ShowVictoryScreen();
        _currentLevelIndex++;
        _currentLevelIndex = Mathf.Clamp(_currentLevelIndex, 0, levelInfoList.Length);
        if (_currentLevelIndex > PlayerPrefs.GetInt(MAX_LEVEL_INDEX)) {
            PlayerPrefs.SetInt(MAX_LEVEL_INDEX, _currentLevelIndex);
        }
        Debug.Log($"NextLeve: {_currentLevelIndex}");
    }

    public LevelInfo GetCurrentLevelInfo() {

        return levelInfoList[_currentLevelIndex];
    }

    public void OpenLevel(int levelIndex) {
        var maxIndex = PlayerPrefs.GetInt(MAX_LEVEL_INDEX);
        Debug.Log($"Trying to open level {levelIndex}, maxlevel: {maxIndex}");
        if (levelIndex <= maxIndex) {
            _currentLevelIndex = levelIndex;
            SceneManager.LoadScene(CURRENT_LEVEL_NAME);
        } else {
            Debug.Log("Trying to access locked level");
        }
    }

    public int GetCurrentLevelIndex() {
        return PlayerPrefs.GetInt(MAX_LEVEL_INDEX);
    }
}
