using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnBuilder", menuName = "ScriptableObjects/Map/SpawnBuilder", order = 1)]
public class SpawnBuilder : ScriptableObject
{
    public Map PlaceSpawns(Map map)
    {

        // Add entry / base
        var tileWithSpawn = Random.Range(0, map.GridHeight);
        map.Grid[tileWithSpawn].IsSpawn = true;

        var tileWithBase = Random.Range(map.GridHeight * (map.GridWidth - 1), map.GridHeight * map.GridWidth);
        Debug.Log("tileWithBase " + tileWithBase);
        map.Grid[tileWithBase].IsBase = true;
        return map;
    }
}
