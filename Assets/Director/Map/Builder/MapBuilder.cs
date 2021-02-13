using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapBuilder", menuName = "ScriptableObjects/Map/MapBuilder", order = 1)]
public class MapBuilder : ScriptableObject
{
    // TODO: use FloatValue ScriptableObject here?
    [SerializeField]
    private int _gridWidth;
    public int GridWidth { get => _gridWidth; set => _gridWidth = value; }

    [SerializeField]
    private int _gridHeight;
    public int GridHeight { get => _gridHeight; set => _gridHeight = value; }

    [SerializeField]
    private MapTerrain[] _availableTerrains;
    public MapTerrain[] AvailableTerrains { get => _availableTerrains; set => _availableTerrains = value; }

    [SerializeField]
    private GridBuilder _gridBuilder;
    public GridBuilder GridBuilder { get => _gridBuilder; set => _gridBuilder = value; }

    [SerializeField]
    private SpawnBuilder _spawnBuilder;
    public SpawnBuilder SpawnBuilder { get => _spawnBuilder; set => _spawnBuilder = value; }

    [SerializeField]
    private PathBuilder _pathBuilder;
    public PathBuilder PathBuilder { get => _pathBuilder; set => _pathBuilder = value; }

    public Map GenerateMap()
    {
        var mapWithGrid = GridBuilder.GenerateGrid(GridWidth, GridHeight, AvailableTerrains);
        var mapWithSpawns = SpawnBuilder.PlaceSpawns(mapWithGrid);
        var mapWithPaths = PathBuilder.BuildPaths(mapWithSpawns);
        return mapWithPaths;
    }
}
