using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTile : MonoBehaviour
{
    public static string curtool = "none";

    public static string GetCurtool()
    {
        return curtool;
    }

    public static void SetCurtool(string value)
    {
        curtool = value;
    }
    public static int count;
   
    public Tilemap tilemap;
    public Tile tile;
    public Sprite grass;
    public Sprite u;
    public Sprite r;
    public Sprite d;
    public Sprite l;

    public Tile up;
    public Tile right;
    public Tile down;
    public Tile left;


    // Update is called once per frame
    private void FixedUpdate()
    {
        count++;
        if (Input.GetMouseButtonDown(0) && ChangeTile.GetCurtool() == "hoe" && count > 1)
        {
    
            Vector3 coordd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coord = tilemap.WorldToCell(coordd);

            if (tilemap.GetSprite(coord) == grass)
            {
                Debug.Log("yea");
                tilemap.SetTile(coord, tile);
                coord.y -= 1;
                Debug.Log(coord.y);
                if (tilemap.GetSprite(coord) == d)
                {
                    Debug.Log("yeayeaa");
                    tilemap.SetTile(coord, down);
                }
                coord.y += 2;
                if (tilemap.GetSprite(coord) == u)
                {
                    Debug.Log("yeayeaaa");
                    tilemap.SetTile(coord, up);
                }
                coord.y -= 1;
                coord.x -= 1;
                if (tilemap.GetSprite(coord) == l)
                {
                    Debug.Log("yeayeaaa");
                    tilemap.SetTile(coord, left);
                }
                coord.x += 2;
                if (tilemap.GetSprite(coord) == r)
                {
                    Debug.Log("yeayeaaa");
                    tilemap.SetTile(coord, right);
                }
            }

        }
        
    }
}
