using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Map
{
    public int GridWidth { get; set; }
    public int GridHeight { get; set; }
    public IList<Tile> Grid { get; set; }
}
