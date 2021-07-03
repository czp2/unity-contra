using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Control : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,0.4f);
    }

    void Update()
    {
        transform.Translate(Vector2.right*4f*Time.deltaTime);
    }
}
