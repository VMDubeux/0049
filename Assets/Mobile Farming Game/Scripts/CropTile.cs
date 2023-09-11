using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileFieldState { Empty, Sown, Watered }

public class CropTile : MonoBehaviour
{
    private TileFieldState _state;

    [Header("Elements")]
    [SerializeField] private Transform _cropParent;

    void Start()
    {
        _state = TileFieldState.Empty;
    }

    void Update()
    {
        
    }

    public void Sow(CropData cropData) 
    {
        _state = TileFieldState.Sown;

        Crop crop = Instantiate(cropData.CropPrefab, transform.position, Quaternion.identity, _cropParent);
    }

    public bool IsEmpty() 
    {
        return _state == TileFieldState.Empty;
    }
}
