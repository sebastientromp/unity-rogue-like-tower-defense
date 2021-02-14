using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PathBuilder", menuName = "ScriptableObjects/Map/PathBuilder", order = 1)]
public class PathBuilder : ScriptableObject
{
    public Map BuildPaths(Map map)
    {
        var path = BuildPathTiles(map);
        // TODO: actually store the path somewhere, as it's important to know what is connected to what,
        // and not just that a tile "is a path"
        var result = MarkPathTiles(map, path);
        return result;
    }

    private Map MarkPathTiles(Map map, List<Tile> path)
    {
        foreach (Tile tile in map.Grid)
        {
            if (IsInPath(path, tile))
            {
                tile.IsPath = true;
            }
        }
        return map;
    }

    private List<Tile> BuildPathTiles(Map map) { 
        var enemySpawn = map.Grid.Where(tile => tile.IsSpawn == true).FirstOrDefault();
        var playerBase = map.Grid.Where(tile => tile.IsBase == true).FirstOrDefault();

        var path = new List<Tile>();
        var currentPathTile = enemySpawn;
        var count = 0;
        Debug.Log("Building path from " + enemySpawn.X + "-" + enemySpawn.Y + " to " + playerBase.X + "-" + playerBase.Y);
        while (true && count < 200)
        {
            count++;
            path.Add(currentPathTile);
            Debug.Log("Adding tile to path " + currentPathTile.X + "-" + currentPathTile.Y);
            // Once we've reached the base, we're done!
            if (currentPathTile.X == playerBase.X && currentPathTile.Y == playerBase.Y)
            {
                Debug.Log("Path done");
                break;
            }

            var nextPossibleDirections = new List<MapPathBuilderDirection>();
            // This path builder never goes back to the left
            nextPossibleDirections.Add(MapPathBuilderDirection.UP);
            nextPossibleDirections.Add(MapPathBuilderDirection.DOWN);
            nextPossibleDirections.Add(MapPathBuilderDirection.RIGHT);

            var x = currentPathTile.X;
            var y = currentPathTile.Y;
            // If we're on the same column as the base, just move in its direction
            if (x == playerBase.X)
            {
                Debug.Log("On final column");
                nextPossibleDirections.Remove(MapPathBuilderDirection.RIGHT);
                if (y > playerBase.Y)
                {
                    nextPossibleDirections.Remove(MapPathBuilderDirection.UP);
                }
                else
                {
                    nextPossibleDirections.Remove(MapPathBuilderDirection.DOWN);
                }
            }
            else
            {
                // We're on the borders of the map
                if (y == 0)
                {
                    nextPossibleDirections.Remove(MapPathBuilderDirection.DOWN);
                }
                else if (y == map.GridHeight - 1)
                {
                    nextPossibleDirections.Remove(MapPathBuilderDirection.UP);
                }

                // Remove the tiles where there already is a path
                nextPossibleDirections.RemoveAll(dir => IsInPath(path, GetTileFrom(map, currentPathTile, dir)));
            }

            var nextTileDirection = nextPossibleDirections[Random.Range(0, nextPossibleDirections.Count)];
            currentPathTile = GetTileFrom(map, currentPathTile, nextTileDirection);
        }

        return path;
    }

    private bool IsInPath(List<Tile> path, Tile tile)
    {
        return path.Where(t => t.X == tile.X && t.Y == tile.Y).Count() > 0;
    }

    private Tile GetTileFrom(Map map, Tile currentPathTile, MapPathBuilderDirection direction)
    {
        switch (direction)
        {
            case MapPathBuilderDirection.UP:
                return map.Grid.Where(tile => tile.X == currentPathTile.X && tile.Y == currentPathTile.Y + 1).FirstOrDefault();
            case MapPathBuilderDirection.DOWN:
                return map.Grid.Where(tile => tile.X == currentPathTile.X && tile.Y == currentPathTile.Y - 1).FirstOrDefault();
            case MapPathBuilderDirection.RIGHT:
                return map.Grid.Where(tile => tile.X == currentPathTile.X + 1 && tile.Y == currentPathTile.Y).FirstOrDefault();
            case MapPathBuilderDirection.LEFT:
                return map.Grid.Where(tile => tile.X == currentPathTile.X - 1 && tile.Y == currentPathTile.Y).FirstOrDefault();
        }
        return null;
    }
}

enum MapPathBuilderDirection
{
    LEFT, RIGHT, UP, DOWN,
}