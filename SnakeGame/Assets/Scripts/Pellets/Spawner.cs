using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> PelletPrefabs;
    [SerializeField] private so_MapData mapData;
    [SerializeField] private so_CollectableController Controller;
    private List<int> SpawnOrder;

  

    // Start is called before the first frame update
    void Start()
    {
        SpawningLoop(1, mapData.Weight - 2, 1, mapData.Length - 2, 0);       
        
        SpawningLoop( mapData.Weight * -1 + 2,  -1, mapData.Length * -1 + 2, -1, 1);         
        
        SpawningLoop( mapData.Weight * -1 + 2,  -1, 1, mapData.Length - 2, 2);         
            



    }

    void SpawningLoop(int xstart, int xEnd, int zStart, int zEnd, int prefabIndex)
    {
    
        for (int x = xstart; x < xEnd; x++)
        {
            for (int z = zStart; z < zEnd; z++)
            {
                GameObject newCollectable = CreateCollectable(PelletPrefabs[prefabIndex], new Vector3(x, 1, z));
                Controller.AddCollectable(newCollectable.GetComponent<Collectable>());
                newCollectable.GetComponent<Collectable>().isCollectable = true;
            }
        }

        Controller.SetMax();
    }
    

    GameObject CreateCollectable(GameObject Prefab,Vector3 SpawnPos)
    {
        return Instantiate(Prefab, SpawnPos, Quaternion.identity);
        
    }
    

}
