using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp=1;
    void Start()
    {
        
    }

    void Update()
    {
        if(hp<1){
            return;
        }
        transform.Translate(Vector2.left*1*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            GetComponent<Animator>().SetBool("isDie",true);
            Destroy(gameObject,0.2f);
            hp=0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag=="DeathLine"){
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject);
            hp=0;
        }
    }
}
