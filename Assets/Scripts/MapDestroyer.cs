using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile brickTile; 
    public Tile wallTile;
    public GameObject explosionPrefab;
    
    int power = 2;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
        for (int i = 1; i <= power; i++) {
            if (!ExplodeCell(originCell + new Vector3Int(i,0,0)))
            {
                break;
            }
        }
        for (int i = 1; i <= power; i++) {
            if (!ExplodeCell(originCell + new Vector3Int(0,i,0)))
            {
                break;
            }
        }
        for (int i = 1; i <= power; i++) {
            if (!ExplodeCell(originCell + new Vector3Int(0-i,0,0)))
            {
                break;
            }
        }
        for (int i = 1; i <= power; i++) {
            if (!ExplodeCell(originCell + new Vector3Int(0,0-i,0)))
            {
                break;
            }
        }
        // ExplodeCell(originCell + new Vector3Int(0,1,0));
        // ExplodeCell(originCell + new Vector3Int(0,2,0));
        // ExplodeCell(originCell + new Vector3Int(-1,0,0));
        // ExplodeCell(originCell + new Vector3Int(-2,0,0));
        // ExplodeCell(originCell + new Vector3Int(0,-1,0));
        // ExplodeCell(originCell + new Vector3Int(0,-2,0));
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
    
        if (tile == wallTile) 
        {
            return false;
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, pos, Quaternion.identity);
     
        if (tile == brickTile)
        {
            tilemap.SetTile(cell, null);
            return false;
        }

        return true;
    }

    
}
