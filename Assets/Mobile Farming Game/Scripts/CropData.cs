using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Corn Data", menuName = "Scriptable Objects/Crop Data", order = 0)]
public class CropData : ScriptableObject
{
    [Header("Settings")]
    public Crop CropPrefab;
}
