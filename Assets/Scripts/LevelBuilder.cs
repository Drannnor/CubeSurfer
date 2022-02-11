using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject finishPrefab;


    private Transform _level;

    private void Awake() {
        _level = transform.GetChild(0);

        if (_level == null) {
            Debug.Log("ERROR: No level found");
        }
    }

    private void Start() {
        

        LevelInfo currentLevelInfo = GetLevelInfo();
        int i;
        for ( i = 0; i < currentLevelInfo.tileList.Length; i++) {
            Vector3 position = new Vector3(0.0f, 0.0f, i * currentLevelInfo.tileSize);
            var tileInfo = currentLevelInfo.tileList[i];
            GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
            LevelTile levelTile = tile.GetComponent<LevelTile>();
            if (levelTile != null) {
                levelTile.SetLevelSpeed(currentLevelInfo.levelSpeed);
                levelTile.SetDestructionDistance(currentLevelInfo.destructionDistance);
                levelTile.Initiate(currentLevelInfo.levelSpeed, currentLevelInfo.destructionDistance,
                    tileInfo.GetWallInfo(), tileInfo.GetPickUpInfo());
            } else {
                Debug.Log("ERROR: unable to find level tile script in level tile");
            }
        }
        //instantiate finish
        Vector3 finishPosition = new Vector3(0.0f, 0.0f, i * currentLevelInfo.tileSize);
        GameObject finish = Instantiate(finishPrefab, finishPosition, Quaternion.identity);
        var movingTile = finish.GetComponent<MovingTile>();
        if (movingTile != null) {
            movingTile.SetDestructionDistance(currentLevelInfo.destructionDistance);
            movingTile.SetLevelSpeed(currentLevelInfo.levelSpeed);
        } else {
            Debug.LogError("ERROR: Couldn't find moving tile script");
        }
    }

    protected  virtual LevelInfo GetLevelInfo() {
        return GameManager.GM.GetCurrentLevelInfo();
    }
}