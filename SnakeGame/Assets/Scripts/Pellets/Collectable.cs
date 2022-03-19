using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectable : MonoBehaviour
{
    public bool isCollectable;
    public int points;
    public EBlockType BlockType;

    public void InitializeBlock(int p_points, EBlockType p_blockType)
    {
        points = p_points;
        BlockType = p_blockType;
    }

    public void DisableCollectable()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}

public enum EBlockType
{
    Red, Blue, Green
}