using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    
    [Range(0,1)]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
    }

    

}
