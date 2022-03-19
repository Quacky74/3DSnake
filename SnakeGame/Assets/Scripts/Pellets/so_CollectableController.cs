using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CollectableController", menuName = "Scriptable/CollectableController")]
public class so_CollectableController : ScriptableObject
{
    private List<Collectable> _collectables;
    public int MAX_COUNT;
    public int count;

    private void OnEnable()
    {
        _collectables = new List<Collectable>();
        count = 0;
        MAX_COUNT = 0;
    }

    public void AddCollectable(Collectable newCollectable)
    {
        _collectables.Add(newCollectable);
        count++;
    }
    
    
    public void RemoveCollectable(Collectable collectable)
    {
        
        --count;
        _collectables.Remove(collectable);
        
    }

    public void SetMax()
    {
        MAX_COUNT = count;
    }

    public int GetMaxCount()
    {
        return MAX_COUNT;
    }

    public int GetCurrentCollectableCount()
    {
        return count;
    }
}
