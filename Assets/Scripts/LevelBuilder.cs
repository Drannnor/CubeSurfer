using UnityEngine;

public class LevelBuilder : MonoBehaviour{

    [SerializeField] private int numberOfTiles = 5;
    [SerializeField] private int tileSize = 10;
    [SerializeField] private float tileSpeed = 2.0f;
    [SerializeField] private GameObject tilePrefab;

    private Transform _level;

    private void Awake(){
        _level = transform.GetChild(0);

        if (_level == null) {
            Debug.Log("ERROR: No level found");
        }
    }

    private void Start(){
        for (int i = -1; i < numberOfTiles; i++) {
            Vector3 position = new Vector3(0.0f,0.0f, i * tileSize);
            GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform.GetChild(0));
            LevelTile levelTile = tile.GetComponent<LevelTile>();
            if (levelTile != null) {
                levelTile.SetTileSpeed(tileSpeed);
            } else {
                Debug.Log("ERROR: unable to find level tile script in level tile");
            }
        }
        
            
    }

    // Update is called once per frame
    void Update(){
        _level.transform.Translate(new Vector3(0.0f, 0.0f, -tileSpeed * Time.deltaTime));
    }
}