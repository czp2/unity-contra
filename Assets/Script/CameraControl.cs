using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float MinX;
    public float MaxX;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 v = transform.position;
        v.x = target.position.x;
        if (v.x > MaxX)
        {
            v.x = MaxX;
        }
        if (v.x < MinX)
        {
            v.x = MinX;
        }
        transform.position = v;
    }

}
