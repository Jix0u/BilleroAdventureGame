using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class planting : MonoBehaviour
{
    public static string curseed = "none";

    public static string GetCurseed()
    {
        return curseed;
    }

    public static void SetCurseed(string value)
    {
        curseed = value;
    }

    class Plantimer
    {
        public Tile curtile;
        public float curtime;
        public Vector3Int curcoord;
        public float curwater;
        public Plantimer(Tile curtile, float curtime, Vector3Int curcoord, float curwater)
        {
            this.curtile = curtile;
            this.curtime = curtime;
            this.curcoord = curcoord;
            this.curwater = curwater;
        }
    }
    public Tilemap floor;
    public Tilemap plants;
    public Sprite hoedirt;
    public Tile wheat1;
    public Tile wheat2;
    public Tile wheat3;
    public Tile wheat4;
    public Tile wheat5;
    public Tile wheat6;
    public Tile wheat7;
    public Tile wet;
    public Tile dry;
    public AnimatedTile wheat8;
    private List<Plantimer> ok = new List<Plantimer>();

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){

            if (ChangeTile.GetCurtool() == "seed")
            {

                Vector3 coordd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int coord = floor.WorldToCell(coordd);

                if (floor.GetSprite(coord) == hoedirt||floor.GetSprite(coord)==wet)
                {
                    Debug.Log("yea");
                    plants.SetTile(coord, wheat1);
                    ok.Add(new Plantimer(wheat1, 0, coord, 500));
                }
            }
            else if (ChangeTile.GetCurtool() == "water")
            {
                Vector3 coordd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int coord = floor.WorldToCell(coordd);
                if(floor.GetTile(coord)==dry)
                    floor.SetTile(coord, wet);
                foreach (Plantimer p in ok)
                {
                    if (p.curcoord == coord)
                    {
                        p.curwater = 500;
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        int index=-1;
        foreach (Plantimer p in ok)
        {
            p.curtime += Time.deltaTime;
            p.curwater -= 1;
            
            if (p.curwater == 0)
            {
                plants.SetTile(p.curcoord, wheat7);
                index = ok.IndexOf(p);
                continue;
            }
            if (p.curwater == 70)
            {
                floor.SetTile(p.curcoord, dry);
            }
            else if (p.curtime > 3 && p.curtile == wheat1)
            {
                plants.SetTile(p.curcoord, wheat2);
                p.curtile = wheat2;
            }
            else if (p.curtime > 6 && p.curtile == wheat2)
            {
                plants.SetTile(p.curcoord, wheat3);
                p.curtile = wheat3;
            }
            else if (p.curtime > 9 && p.curtile == wheat3)
            {
                plants.SetTile(p.curcoord, wheat4);
                p.curtile = wheat4;
            }
            else if (p.curtime > 12 && p.curtile == wheat4)
            {
                plants.SetTile(p.curcoord, wheat5);
                p.curtile = wheat5;
            }
            else if (p.curtime > 15 && p.curtile == wheat5)
            {
                plants.SetTile(p.curcoord, wheat6);
                p.curtile = wheat6;
            }
            else if (p.curtime > 18 && p.curtile == wheat6)
            {
                plants.SetTile(p.curcoord, wheat8);
                floor.SetTile(p.curcoord, dry);
                index = ok.IndexOf(p);
                continue;
            }
        }
        if (index != -1) ok.RemoveAt(index);
    }
}
