using System.Collections.Generic;
using UnityEngine;

public class LevelTile : MovingTile {
   
    [SerializeField] private GameObject cubeWallPrefab;
    [SerializeField] private GameObject cubePickUpPrefab;
    [SerializeField] private Vector3 wallOffset = new Vector3(-2.0f, 1.0f, 4.5f);

    
    public void Initiate(float levelSpeed, float destructionDistance, int[] wallInfo, Vector2[] pickupInfo) {
        
        SetLevelSpeed(levelSpeed);
        SetDestructionDistance(destructionDistance);
        CreateWall(wallInfo);
        SpawnPickUps(pickupInfo);
    }

    private void SpawnPickUps(IEnumerable<Vector2> pickupInfo) {
        foreach (var position in pickupInfo) {
            var pickUpObject = Instantiate(cubePickUpPrefab, transform, false);
            pickUpObject.transform.localPosition = new Vector3(position.x, 1.0f, position.y);
        }
    }

    private void CreateWall(int[] wallInfo) {
        var wallObject = Instantiate(cubeWallPrefab, transform, false);
        wallObject.transform.localPosition = wallOffset;

        CubeWall cubeWall = wallObject.GetComponent<CubeWall>();
        if (cubeWall != null) {
            cubeWall.SetCubeWallInfo(wallInfo);
            cubeWall.Initiate();
        } else {
            Debug.LogError("ERROR: Couldn't find CubeWall script");
        }
    }

}