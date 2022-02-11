using UnityEngine;

public class GameManager : MonoBehaviour{
    [Header("GameManager")] public static GameManager GM;

    private GameMenuController _gameMenuController;
    private void Awake(){
        if (GM != null)
            Destroy(GM);
        else
            GM = this;

        DontDestroyOnLoad(GM);
    }

    public void SetGameMenuController(GameMenuController gmc) {
        _gameMenuController = gmc;
    }

    public GameMenuController GetGameMenuController() {
        return _gameMenuController;
    }

    public void LevelFinished() {
        _gameMenuController.ShowVictoryScreen();
    }
}
