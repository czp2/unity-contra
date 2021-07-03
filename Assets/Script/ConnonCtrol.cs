using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnonCtrol : MonoBehaviour
{
    public int HP=10;
    public Transform gl;
    public GameObject BulletPre;
    private float timer=0;
    public Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }
    void Update()
    {
        if(player==null){
            return;
        }
        if(HP<1){
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject,1f);
            GetComponent<Animator>().SetBool("isCdie",true);
        }
        float dis = Vector2.Distance(transform.position,player.position);
        if(dis<1.5f){
            timer+=Time.deltaTime;
            if(timer>1f){
                timer=0;
                Shoot();
            }
        }
    }
    void Shoot(){
        GameObject.Instantiate(BulletPre,gl.position,gl.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            HP=HP-1;
        }
    }
}
