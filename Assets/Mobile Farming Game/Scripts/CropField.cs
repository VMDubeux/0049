using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CropField : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform _tilesParent;
    private List<CropTile> _cropTiles = new List<CropTile>();

    [Header("Settings")]
    [SerializeField] private CropData _cropData;
    private TileFieldState _state;
    private int _tilesSown;

    [Header("Action")]
    public static Action<CropField> onFullySown;

    void Start()
    {
        _state = TileFieldState.Empty;
        StoreTiles();
    }

    void Update()
    {

    }

    private void StoreTiles()
    {
        for (int i = 0; i < _tilesParent.childCount; i++)
        {
            _cropTiles.Add(_tilesParent.GetChild(i).GetComponent<CropTile>());
        }
    }

    public void SeedsCollidedCallback(Vector3[] seedsPositions)
    {
        for (int i = 0; i < seedsPositions.Length; i++)
        {
            CropTile closestCropTile = GetClosestCropTile(seedsPositions[i]);

            if (closestCropTile == null)
                continue;

            if (!closestCropTile.IsEmpty())
                continue;

            Sow(closestCropTile);
        }
    }

    private void Sow(CropTile cropTile)
    {
        cropTile.Sow(_cropData);
        _tilesSown++;

        if (_tilesSown == _cropTiles.Count)
            FieldFullySown();
    }

    private void FieldFullySown() 
    {
        _state = TileFieldState.Sown;

        onFullySown?.Invoke(this);
    }

    private CropTile GetClosestCropTile(Vector3 seedsPosition)
    {
        float minDistance = 5000;
        int closestCropTileIndex = -1;

        for (int i = 0; i < _cropTiles.Count; i++)
        {
            CropTile cropTile = _cropTiles[i];
            float distanceTileSeed = Vector3.Distance(cropTile.transform.position, seedsPosition);

            if (distanceTileSeed < minDistance)
            {
                minDistance = distanceTileSeed;
                closestCropTileIndex = i;
            }
        }

        if (closestCropTileIndex == -1)
            return null;

        return _cropTiles[closestCropTileIndex];
    }

    public bool IsEmpty()
    {
        return _state == TileFieldState.Empty;
    }
}
