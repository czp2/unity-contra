using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Control : MonoBehaviour
{
    public int HP=1;
    public Transform gl;
    public GameObject BulletPre;
    private float timer=0;
    void Start()
    {
        
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>1f){
            timer=0;
            Shoot();
        }
    }
    void Shoot(){
        GameObject.Instantiate(BulletPre,gl.position,gl.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            HP=0;
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
    }
}
