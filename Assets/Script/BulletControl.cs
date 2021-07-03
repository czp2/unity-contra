using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public static float speed=4f;
    void Start()
    {
        Destroy(gameObject,0.5f);
    }

    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }
}
