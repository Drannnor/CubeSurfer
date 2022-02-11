using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour{
    private const string MAX_LEVEL_INDEX = "MaxLevelReached";
    [Header("GameManager")] public static GameManager GM;

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
        if (_currentLevelIndex > PlayerPrefs.GetInt(MAX_LEVEL_INDEX)) {
            PlayerPrefs.SetInt(MAX_LEVEL_INDEX, _currentLevelIndex);
        }
    }

    public LevelInfo GetCurrentLevelInfo() {

        return levelInfoList[_currentLevelIndex];
    }
    
}
