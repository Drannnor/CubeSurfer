using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelInfo.asset", menuName = "LevelInfo/LevelInfo")]
public class LevelInfo : ScriptableObject {
    [FormerlySerializedAs("TileList")] public TileInfo[] tileList;
    public float tileSize;
    public float levelSpeed;
    public float destructionDistance;
}