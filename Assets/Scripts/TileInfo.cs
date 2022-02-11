using System;
using UnityEngine;

[Serializable] 
public class TileInfo {
    [SerializeField]private int[] _wallInfo;

    [SerializeField]private Vector2[] _pickUpPositions;
    

    public TileInfo(int[] wallInfo, Vector2[] pickUpPositions) {
        _wallInfo = (int[])wallInfo.Clone();
        _pickUpPositions = (Vector2[])pickUpPositions.Clone();
    }

    public int[] GetWallInfo() {
        return _wallInfo;
    }

    public Vector2[] GetPickUpInfo() {
        return _pickUpPositions;
    }
}