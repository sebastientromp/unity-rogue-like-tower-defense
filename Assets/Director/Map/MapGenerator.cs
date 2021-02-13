using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapGenerator", menuName = "ScriptableObjects/Map/MapGenerator", order = 1)]
public class MapGenerator : ScriptableObject
{
    [SerializeField]
    private MapBuilder _mapBuilder;
    public MapBuilder MapBuilder { get => _mapBuilder; set => _mapBuilder = value; }

    [SerializeField]
    private MapRenderer _mapRenderer;
    public MapRenderer MapRenderer { get => _mapRenderer; set => _mapRenderer = value; }

    public void GenerateMap()
    {
        var existingMap = GameObject.Find("TestMap");
        if (existingMap != null)
        {
            DestroyImmediate(existingMap);
        }
        Map map = MapBuilder.GenerateMap();
        MapRenderer.RenderMap(map, "TestMap");
    }
}
