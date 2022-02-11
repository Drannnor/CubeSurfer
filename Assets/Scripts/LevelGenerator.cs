using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : LevelBuilder {
    [SerializeField] private LevelInfo newLevel;
    [SerializeField] private int minNumberOfTiles = 6;
    [SerializeField] private int maxNumberOfTiles = 10;
    [SerializeField] private float destructionDistance = 10.0f;
    [SerializeField] private float levelSpeed = 5.0f;
    [SerializeField] private float tileSize = 10.0f;

    private int _maxNumberOfCubes = 1;

    protected override LevelInfo GetLevelInfo() {
        //Generate level;
        newLevel.destructionDistance = destructionDistance;
        newLevel.levelSpeed = levelSpeed;
        newLevel.tileSize = tileSize;
        newLevel.tileList = GenerateTileList();

        return newLevel;
    }

    private TileInfo[] GenerateTileList() {
        int numberOfTiles = Random.Range(0, maxNumberOfTiles - minNumberOfTiles) + minNumberOfTiles;
        TileInfo[] newTileList = new TileInfo[numberOfTiles];
        for (int i = 0; i < numberOfTiles; i++) {
            Vector2[] pickUpPositions = i == 0 ? Array.Empty<Vector2>() : GeneratePickUpPositions();
            var wallInfo = i == 0 ? new int[5] : GenerateCubeWallInfo();
            newTileList[i] = new TileInfo(wallInfo, pickUpPositions);
        }

        return newTileList;
    }

    private Vector2[] GeneratePickUpPositions() {
        var numberOfPickUps = Random.Range(1, 3);
        Vector2[] pickupPositions = new Vector2[numberOfPickUps];
        for (int i = 0; i < numberOfPickUps; i++) {
            _maxNumberOfCubes++;
            pickupPositions[i] = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        }
        Debug.Log($"max cubes  {_maxNumberOfCubes} pickups");


        return pickupPositions;
    }

    private int[] GenerateCubeWallInfo() {
        int[] result = new int[5];
    
        int openingPosition = Random.Range(0, 5);   
        var doorwayHeight = Random.Range(1, _maxNumberOfCubes);
        _maxNumberOfCubes -= doorwayHeight;
        Debug.Log($"doorway height: {doorwayHeight}, maxNumberOfCubes: {_maxNumberOfCubes}");
        for (int i = 0; i < 5; i++) {
            if (i == openingPosition || i == (openingPosition + 1)) {
                result[i] = doorwayHeight;
            } else {
                result[i] = Random.Range(1, 4);
            }
        }
        return result;
    }
}