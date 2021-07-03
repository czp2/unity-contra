using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAwardControl : MonoBehaviour
{
    public GameObject AwardPre;
    void Start()
    {
        Destroy(gameObject,15f);
    }

    void Update()
    {
        transform.Translate(Vector2.right*1*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject,0.2f);
            GameObject.Instantiate(AwardPre,transform.position,transform.rotation);
        }
    }
}
