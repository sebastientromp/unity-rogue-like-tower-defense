using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapRenderer", menuName = "ScriptableObjects/Map/MapRenderer", order = 1)]
public class MapRenderer : ScriptableObject
{
    [SerializeField]
    private GameObject _castle;
    public GameObject Castle { get => _castle; set => _castle = value; }

    [SerializeField]
    private Texture2D _pathTexture;
    public Texture2D PathTexture { get => _pathTexture; set => _pathTexture = value; }

    public void RenderMap(Map map, string objectName = "Map")
    {
        Debug.Log("Rendering map");
        GameObject theMap = new GameObject(objectName);
        for (int i = 0; i < map.GridWidth; i++)
        {
            for (int j = 0; j < map.GridHeight; j++)
            {
                var tile = map.Grid[i * map.GridHeight + j];
                HasTerrain tileObj = Instantiate<HasTerrain>(tile.Terrain.MapTile, new Vector3(i, 0, j), Quaternion.identity);
                tileObj.transform.parent = theMap.transform;

                // Setting the texture
                tileObj.SetTexture(tile.Terrain.Texture); 
                if (tile.IsPath)
                {
                    Debug.Log("Rendering path");
                    tileObj.SetTexture(PathTexture);
                }

                // Setting the spawn point flag
                if (tile.IsBase)
                {
                    //GameObject castle = Instantiate(Castle, new Vector3(0, 0, 0), Quaternion.identity);
                    GameObject castle = Instantiate(Castle);
                    castle.transform.parent = tileObj.transform;
                    castle.transform.localPosition = new Vector3(0, 0, 0);
                    castle.transform.rotation = Quaternion.identity;
                }



            }
        }
    }
}
