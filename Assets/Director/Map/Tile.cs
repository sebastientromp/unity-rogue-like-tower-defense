using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tile
{
    public int X { get; set; }

    public int Y { get; set; }

    public MapTerrain Terrain { get; set; }

    public bool IsSpawn { get; set; }

    public bool IsBase { get; set; }

    public bool IsPath { get; set; }
}