using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunControl : MonoBehaviour
{
    public int HP=10;
    public Transform gun;
    public GameObject BulletPre;
    private float timer=0;
    void Start()
    {
        
    }
    void Update()
    {
        if(HP<1){
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody2D>());
            if(gameObject.name=="boss-gun1"){
                GetComponent<Animator>().SetBool("isG1die",true);
            }else{
                GetComponent<Animator>().SetBool("isG2die",true);
            }
            Destroy(gameObject,0.5f);
            
        }
        timer+=Time.deltaTime;
        if(timer>0.3f){
            timer=0;
            Shoot();
        }
    }
    void Shoot(){
        GameObject.Instantiate(BulletPre,gun.position,gun.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            HP=HP-1;
        }
    }
}
