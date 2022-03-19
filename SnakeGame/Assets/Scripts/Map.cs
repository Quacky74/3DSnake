using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private so_MapData mapData;
    [SerializeField] private GameObject wallTile;
    [SerializeField] private GameObject floorTile;

    // Start is called before the first frame update
    void Start()
    {
        for (int X = mapData.Weight * -1; X < mapData.Weight; X++)
        {
            for (int Z = mapData.Length * -1; Z < mapData.Length ; Z++)
            {
                GameObject newTile = Instantiate(floorTile, new Vector3(X, 0, Z), Quaternion.identity);
                newTile.transform.SetParent(this.transform);

                if (X == mapData.Weight * -1 || X == mapData.Weight - 1 || Z == mapData.Length * -1 || Z== mapData.Length - 1)
                {
                    GameObject wall = Instantiate(wallTile, this.transform, true);
                    wall.transform.parent = this.transform;
                    wall.transform.position = new Vector3(X, 1, Z);
                    wall.tag = "Wall";
                }
            }
        }
    }

}
