using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardControl : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag=="player"){
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
    }
}
