using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PathBuilder", menuName = "ScriptableObjects/Map/PathBuilder", order = 1)]
public class PathBuilder : ScriptableObject
{
    public Map BuildPaths(Map map)
    {
        var enemySpawn = map.Grid.Where(tile => tile.IsSpawn == true).FirstOrDefault();
        var playerBase = map.Grid.Where(tile => tile.IsBase == true).FirstOrDefault();

        var path = new List<Tile>();
        var currentPathTile = enemySpawn;
        while (true)
        {
            path.Add(currentPathTile);
            if (currentPathTile.X == playerBase.X && currentPathTile.Y == playerBase.Y)
            {
                break;
            }
        }
        
        // Build a path from the spawn to the base
        // Ideas:
        // - Should connect both points
        // - Should not loop
        // - Should try to have some straight lines
        return map;
    }
}
