using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeWall : MonoBehaviour {
    [SerializeField]private int[] _cubeWallInfo = { 1, 1, 1, 1, 2 };

    [SerializeField] private GameObject obstacleCubePrefab;
    public bool isUsed;

    // Start is called before the first frame update
    void Start() {
        isUsed = false;
        for (var x = 0; x < _cubeWallInfo.Length; x++) {
            for (var y = 0; y < _cubeWallInfo[x]; y++) {
                var obstacleCube = Instantiate(obstacleCubePrefab, transform, false);
                var offset = new Vector3(x, y, 0.0f);
                obstacleCube.transform.localPosition = offset;
            }
        }
    }

    public int GetWallHeight(Vector3 playerPosition) {
        if (isUsed) return 0;
        var discretePosition = playerPosition.x + 2.5f;//TODO fix magic numbers
        var positionFloor = Mathf.FloorToInt(discretePosition);
        var rest = discretePosition - positionFloor;

        var offset = rest > 0.5f ? 1 : -1;
        var OffSetIndex = Mathf.Clamp(positionFloor + offset, 0, 4);//TODO fix magic numbers
        isUsed = true;
        
        Debug.Log($"discrete position: {discretePosition}, position floor: {positionFloor}, offsetIndex: {OffSetIndex}");
        var maxHeight = Math.Max(_cubeWallInfo[positionFloor], _cubeWallInfo[OffSetIndex]);
        return maxHeight;
    }
}