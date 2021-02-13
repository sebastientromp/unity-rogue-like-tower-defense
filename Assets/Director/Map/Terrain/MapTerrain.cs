using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapTerrain", menuName = "ScriptableObjects/MapTerrain", order = 1)]
[System.Serializable]
public class MapTerrain : ScriptableObject
{
    [SerializeField]
    private Texture2D _texture;
    public Texture2D Texture { get => _texture; set => _texture = value; }

    [SerializeField]
    private HasTerrain _mapTile;
    public HasTerrain MapTile { get => _mapTile; set => _mapTile = value; }
}
