using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridBuilder", menuName = "ScriptableObjects/Map/GridBuilder", order = 1)]
public class GridBuilder : ScriptableObject
{
    public Map GenerateGrid(int gridWidth, int gridHeight, MapTerrain[] availableTerrains)
    {
        // Generate the base grid
        IList<Tile> Grid = new List<Tile>();
        for (var x = 0; x < gridWidth; x++)
        {
            for (var y = 0; y < gridHeight; y++)
            {
                Tile tile = new Tile()
                {
                    X = x,
                    Y = y,
                    Terrain = availableTerrains[0],
                };
                Grid.Add(tile);
            }
        }

        return new Map()
        {
            GridWidth = gridWidth,
            GridHeight = gridHeight,
            Grid = Grid,
        };
    }
}
